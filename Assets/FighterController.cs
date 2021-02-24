using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

// Controls all logic related to the fighters
public class FighterController : PhysicsObject
{

    public GameObject hitParticles;
    public GameObject specialParticles;
    public GameObject fighterTrail;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private AttackManager attackManager;
    private PlayerInput playerInput;

    private Vector2 move;
    private bool isDashing = false;
    private bool isJumping = false;
    private bool isAttacking = false;
    private bool isBlocking = false;
    private bool isDodging = false;
    private float currentMovex = 0;
    private float stunTime = 0;
    private float currentStunMax = 0;
    private float currentKnockback = 0;
    private float currentBlockDelay = 0;
    private int dashTap = 0;

    private const float doubleTapTimeLimit = 0.25f;
    private const float frame = 0.02f;
    private const float specialSlowRate = 0.1f;
    public FloatVariable trailLifetime;

    // Events

    public PositionEvent OnDamaged;

    // Stats

    public int attack = 1;
    public int defence = 2;
    public FloatVariable health;
    public FloatVariable specialMeter;
    public FloatVariable maxSpecial;

    // Opponent Gauge

    public FloatVariable enemySpecialMeter;
    public FloatVariable enemyMaxSpecial;

    // Per-character constants

    public float horizontalMoveSpeed = 5;
    public float dashSpeed = 10;
    public float dashLength = 18;
    public float jumpSpeed = 7;
    public float blockDamagePercent = 0.25f;
    public float blockDelay = 0.3f;
    public float blockKnockbackMultiplier = 0.35f;

    // General public variables

    public bool isFacingRight;

    private void Awake() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        attackManager = GetComponent<AttackManager>();
        playerInput = GetComponent<PlayerInput>();
    }

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable() 
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }

    public void DisableInput()
    {
        playerInput.enabled = false;
        move.x = 0;
    }

    protected override void Update() 
    {

        targetVelocity = Vector2.zero;
        
        if (stunTime > 0) {
            stunTime -= Time.deltaTime;
            if (stunTime <= 0) {
                move.x = currentMovex * horizontalMoveSpeed;
                animator.SetBool("HitStun", false);
            }
            else {
                move.x = Mathf.Lerp(0, currentKnockback, stunTime / currentStunMax);
                if (isFacingRight) move.x *= -1;
            }
        }

        if (currentBlockDelay > 0) {
            currentBlockDelay -= Time.deltaTime;
        }

        ComputeVelocity ();
        animator.SetFloat("xSpeed", Math.Abs(move.x));
    }

    protected override void ComputeVelocity()
    {
        targetVelocity = move;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        currentMovex = context.ReadValue<float>();
        if (!isJumping && !isDashing && !IsCharacterBusy()) {
            move.x = currentMovex * horizontalMoveSpeed;
            if (context.phase == InputActionPhase.Performed) {
                StartCoroutine(Dash((int)context.ReadValue<float>()));
            }
        }
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (grounded && !IsCharacterBusy()) {
            velocity.y = jumpSpeed;
            StartCoroutine(Jump());
        }
    }

    public void OnLAtk(InputAction.CallbackContext context)
    {
        animator.SetTrigger("LAtk");
        if (grounded && !isDashing) {
            attackManager.StandingLAtk(attack);
            StartCoroutine(GroundAttack());
        }
    }

    public void OnMAtk(InputAction.CallbackContext context)
    {
        animator.SetTrigger("MAtk");
        if (grounded && !isDashing) {
            attackManager.StandingMAtk(attack);
            StartCoroutine(GroundAttack());
        }
    }

    public void OnHAtk(InputAction.CallbackContext context)
    {
        animator.SetTrigger("HAtk");
        if (grounded && !isDashing) {
            attackManager.StandingHAtk(attack);
            StartCoroutine(GroundAttack());
        }
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        bool blockPress = (int)context.ReadValue<float>() == 1;

        if (!IsCharacterBusy() && !isDashing && grounded && blockPress) {
            isBlocking = true;
            move.x = 0;
            animator.SetBool("isBlocking", isBlocking);
        }
        else if (isBlocking && !blockPress) {
            isBlocking = false;
            move.x = currentMovex * horizontalMoveSpeed;
            animator.SetBool("isBlocking", isBlocking);
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!IsCharacterBusy() && !isDashing && grounded) {
            move.x = 0;
            animator.SetTrigger("Dodge");
        }
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        if (!IsCharacterBusy() && !isDashing && grounded) {
            move.x = 0;
            StartCoroutine(SpecialMove());
        }
    }

    IEnumerator Jump()
    {
        isJumping = true;
        animator.SetTrigger("Jump");
        animator.SetBool("Grounded", false);
        yield return new WaitForSeconds(frame);
        yield return new WaitUntil(() => grounded);
        move.x = currentMovex * horizontalMoveSpeed;
        animator.SetBool("Grounded", grounded);
        isJumping = false;
    }

    IEnumerator Dash(int moveDirection)
    {
        if (dashTap != moveDirection) {
            dashTap = moveDirection;
            yield return new WaitForSeconds(doubleTapTimeLimit);
            dashTap = 0;
        } else {
            isDashing = true;
            animator.SetBool("isDashing", true);
            move.x = moveDirection * dashSpeed;
            InvokeRepeating("SpawnTrail", 0, 0.1f);
            yield return new WaitForSeconds(dashLength * frame);
            if (!isJumping) {
                move.x = currentMovex * horizontalMoveSpeed;
            }
            animator.SetBool("isDashing", false);
            isDashing = false;
            CancelInvoke();
        }
    }

    IEnumerator GroundAttack()
    {
        isAttacking = true;
        move.x = 0;
        yield return new WaitUntil(() => !isAttacking);
    }

    public void EndAttack()
    {
        isAttacking = false;
        animator.SetTrigger("AtkEnd");
        move.x = currentMovex * horizontalMoveSpeed;
    }

    public void Hit(float damage, float knockback, float hitstun, float blockstun, bool knockdown, Vector2 contactPoint)
    {
        if (isBlocking)
        {
            Blocked(damage, knockback, blockstun);
        }
        else if (isDodging)
        {
            Dodged(damage);
        }
        else
        {
            Damaged(damage, knockback, hitstun);
            StartCoroutine(SpawnHitParticles(contactPoint));
        }

    }

    private void Damaged(float damage, float knockback, float hitstun)
    {
        currentStunMax = hitstun * frame;
        stunTime = currentStunMax;
        currentKnockback = knockback;
        health.Value -= DamageTaken(damage);
        animator.SetBool("HitStun", true);
        AddSpecial(damage * 0.1f);
        AddEnemySpecial(damage * 1f);
    }

    private void Blocked(float damage, float knockback, float blockstun)
    {
        currentStunMax = blockstun * frame;
        stunTime = currentStunMax;
        currentKnockback = knockback * blockKnockbackMultiplier;
        health.Value -= DamageTaken(damage) * blockDamagePercent;
        AddSpecial(damage * 0.35f);
        AddEnemySpecial(damage * .35f);
    }

    private void Dodged(float damage)
    {
        AddSpecial(damage * 1.2f);
    }

    private bool IsCharacterBusy()
    {
        return isBlocking || isAttacking || isDodging || stunTime > 0;
    }

    private float DamageTaken(float damage)
    {
        return damage * (1 / (float)Math.Pow(defence, 0.5));
    }

    public void DodgeStart()
    {
        isDodging = true;
    }

    public void DodgeEnd()
    {
        isDodging = false;
        animator.SetTrigger("EndDodge");
        move.x = currentMovex * horizontalMoveSpeed;
    }

    public void AnimateForward(float speed)
    {
        move.x = speed;
        if (!isFacingRight) move.x *= -1;
    }

    public void StopMovement()
    {
        move.x = 0;
    }

    public void JumpLAtk()
    {
        isAttacking = true;
        attackManager.JumpingLAtk(attack);
    }

    public void JumpMAtk()
    {
        isAttacking = true;
        attackManager.JumpingMAtk(attack);
    }

    public void JumpHAtk()
    {
        isAttacking = true;
        attackManager.JumpingHAtk(attack);
    }

    public void DashAtk()
    {
        isAttacking = true;
        attackManager.DashAtk(attack);
    }

    private void AddSpecial(float specialGain)
    {
        if (specialMeter.Value + specialGain > maxSpecial.Value) {
            specialMeter.Value = maxSpecial.Value;
        }
        else {
            specialMeter.Value += specialGain;
        }
    }

    private void AddEnemySpecial(float specialGain)
    {
        if (enemySpecialMeter.Value + specialGain > enemyMaxSpecial.Value) {
            enemySpecialMeter.Value = enemyMaxSpecial.Value;
        }
        else {
            enemySpecialMeter.Value += specialGain;
        }
    }

    IEnumerator SpawnHitParticles(Vector2 spawnPoint)
    {
        GameObject particle = Instantiate(hitParticles, spawnPoint, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
        yield return new WaitForSeconds(1f);
        Destroy(particle);
    }

    IEnumerator SpecialMove()
    {
        GameObject particle = Instantiate(specialParticles, transform.position, Quaternion.identity);
        particle.GetComponent<ParticleSystem>().Play();
        Time.fixedDeltaTime *= specialSlowRate;
        Time.timeScale = specialSlowRate;
        yield return new WaitForSeconds(0.1f);
        Time.fixedDeltaTime *= (1 / specialSlowRate);
        Time.timeScale = 1.0f;
        Destroy(particle);
    }

    private void SpawnTrail()
    {
        GameObject trail = Instantiate(fighterTrail, transform.position, Quaternion.identity);
        trail.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
        if (!isFacingRight)
        {
            trail.transform.localScale = new Vector3(-1, 1, 1);
        }
        Destroy(trail, trailLifetime.Value);
    }

}
