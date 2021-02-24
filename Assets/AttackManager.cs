using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour
{

    protected Animator animator;
    protected HitBoxScript hitBoxScript;

    protected void Awake() {
        animator = GetComponent<Animator>();
        hitBoxScript = gameObject.GetComponentInChildren<HitBoxScript>();
    }

    public virtual void StandingLAtk(int attack)
    {

    }

    public virtual void StandingMAtk(int attack)
    {

    }

    public virtual void StandingHAtk(int attack)
    {

    }

    public virtual void JumpingLAtk(int attack)
    {

    }
    
    public virtual void JumpingMAtk(int attack)
    {

    }

    public virtual void JumpingHAtk(int attack)
    {

    }

    public virtual void DashAtk(int attack) {}

    protected float DamageCalc(float damage, int attack)
    {
        return damage * (1 + (attack * 1 / 20));
    }
}
