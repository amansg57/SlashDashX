using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Smoothly animates health bar changes
public class HealthBarScript : MonoBehaviour
{
    public FloatVariable maxHP;
    public FloatVariable playerHP;

    private Image bar;
    private Image damageCapImage;
    private float healthPercent;
    private float currentHPBarPercent;
    private float damageCap;
    private float smoothVelocity;
    private float smoothTime = 0.3f;

    private void Start()
    {
        GameObject barObject = transform.GetChild(2).gameObject;
        bar = barObject.GetComponent<Image>();
        GameObject damageCapObject = transform.GetChild(3).gameObject;
        damageCapImage = damageCapObject.GetComponent<Image>();
    }

    private void Update() {
        healthPercent = playerHP.Value / maxHP.Value;
        currentHPBarPercent = Mathf.SmoothDamp(currentHPBarPercent, healthPercent, ref smoothVelocity, smoothTime);
        bar.fillAmount = currentHPBarPercent;
    }

    public void SetDamageCap(float percent)
    {
        damageCap = percent;
        damageCapImage.fillAmount = damageCap;
    }


}
