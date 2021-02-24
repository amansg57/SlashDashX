using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Holds properties of an attack, and pushes these to enemy if hit
public class HitBoxScript : MonoBehaviour
{

    private float damage, knockback, hitstun, blockstun;
    private bool knockdown;

    public void setParameters(float dmg, float kb, float hs, float bs, bool kd) {
        damage = dmg;
        knockback = kb;
        hitstun = hs;
        blockstun = bs;
        knockdown = kd;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Fighter") && collision.collider.gameObject != transform.parent.gameObject) {
            collision.collider.gameObject.GetComponent<FighterController>().Hit(damage, knockback, hitstun, blockstun, knockdown, collision.GetContact(0).point);
        }
    }

}
