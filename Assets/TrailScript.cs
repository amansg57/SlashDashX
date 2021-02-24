using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Creates a trail of sprites behind the target for a 'motion' effect
public class TrailScript : MonoBehaviour
{
    public FloatVariable lifetime;
    private SpriteRenderer spriteRenderer;
    private float aliveTime;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update() {
        aliveTime += Time.deltaTime;
        Color color = spriteRenderer.color;
        color.a = Mathf.Lerp(1.0f, 0f, aliveTime / lifetime.Value);
        spriteRenderer.color = color;
    }
}
