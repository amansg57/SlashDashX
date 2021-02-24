using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Adapted from https://learn.unity.com/tutorial/live-session-2d-platformer-character-controller
public class PhysicsObject : MonoBehaviour {

    public float minGroundNormalY = 0.95f;
    public float gravityModifier = 2f;
    public Transform groundCheckPoint;
    public LayerMask groundLayer;
    public LayerMask fighterLayer;

    protected Vector2 targetVelocity;
    protected bool grounded;
    protected Vector2 groundNormal;
    protected Rigidbody2D rb2d;
    public Collider2D c2D;
    protected Vector2 velocity;
    protected ContactFilter2D arenaFilter, fighterFilter;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D> hitBufferList = new List<RaycastHit2D> (16);


    protected const float minMoveDistance = 0.001f;
    protected const float shellRadius = 0.01f;

    void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected virtual void Start () 
    {
        arenaFilter.useTriggers = false;
        arenaFilter.SetLayerMask (groundLayer);
        arenaFilter.useLayerMask = true;
        fighterFilter.useTriggers = false;
        fighterFilter.SetLayerMask (fighterLayer);
        fighterFilter.useLayerMask = true;
    }

    protected virtual void Update () 
    {
        targetVelocity = Vector2.zero;
        ComputeVelocity ();
    }

    protected virtual void ComputeVelocity()
    {

    }

    protected void FixedUpdate()
    {
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetVelocity.x;

        grounded = false;

        Vector2 deltaPosition = velocity * Time.deltaTime;

        Vector2 moveAlongGround = new Vector2 (groundNormal.y, -groundNormal.x);

        Vector2 move = moveAlongGround * deltaPosition.x;

        HorizontalMovement (move);

        move = Vector2.up * deltaPosition.y;

        VerticalMovement (move);
    }

    void VerticalMovement(Vector2 move)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance) 
        {
            int count = c2D.Cast (move, arenaFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear ();
            for (int i = 0; i < count; i++) {
                hitBufferList.Add (hitBuffer [i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++) 
            {
                Vector2 currentNormal = hitBufferList [i].normal;
                if (currentNormal.y > minGroundNormalY) 
                {
                    grounded = true;
                    groundNormal = currentNormal;
                    currentNormal.x = 0;
                }

                float modifiedDistance = hitBufferList [i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

            if (!grounded) {
                count = c2D.Cast (move, fighterFilter, hitBuffer, distance + shellRadius);
                hitBufferList.Clear ();
                for (int i = 0; i < count; i++) {
                    hitBufferList.Add (hitBuffer [i]);
                }

                for (int i = 0; i < hitBufferList.Count; i++) 
                {
                    Vector2 currentNormal = hitBufferList [i].normal;

                    Vector2 pushVector = new Vector2 (currentNormal.y, -currentNormal.x);
                    move = move * pushVector;
                }
            }

        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }

    void HorizontalMovement(Vector2 move)
    {
        float distance = move.magnitude;

        if (distance > minMoveDistance) 
        {
            int count = c2D.Cast (move, fighterFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear ();
            for (int i = 0; i < count; i++) {
                hitBufferList.Add (hitBuffer [i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++) 
            {
                float modifiedDistance = hitBufferList [i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

            count = c2D.Cast (move, arenaFilter, hitBuffer, distance + shellRadius);
            hitBufferList.Clear ();
            for (int i = 0; i < count; i++) {
                hitBufferList.Add (hitBuffer [i]);
            }

            for (int i = 0; i < hitBufferList.Count; i++) 
            {
                float modifiedDistance = hitBufferList [i].distance - shellRadius;
                distance = modifiedDistance < distance ? modifiedDistance : distance;
            }

        }

        rb2d.position = rb2d.position + move.normalized * distance;
    }

}