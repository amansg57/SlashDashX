using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Smoothly animates special bar changes
public class SpecialBarScript : MonoBehaviour
{
    public FloatVariable special;
    public FloatVariable maxSpecial;

    private Image bar;
    private float specialPercent;
    private float currentSpecialBarPercent;
    private float smoothVelocity;
    private float smoothTime = 0.3f;
    
    private void Start() {
        GameObject barObject = transform.GetChild(2).gameObject;
        bar = barObject.GetComponent<Image>();
    }

    private void Update() {
        specialPercent = special.Value / maxSpecial.Value;
        currentSpecialBarPercent = Mathf.SmoothDamp(currentSpecialBarPercent, specialPercent, ref smoothVelocity, smoothTime);
        bar.fillAmount = currentSpecialBarPercent;
    }

}
