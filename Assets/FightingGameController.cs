using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// General game logic controller
public class FightingGameController : MonoBehaviour
{
    public FightingGameLoadArguments loadArguments;
    public CameraScript cameraScript;
    public HealthBarScript p1HPBarScript, p2HPBarScript;
    public TextMeshProUGUI timer;
    public GameObject roundOver;
    public GameObject hitParticles;
    
    public FloatVariable p1HP, p2HP, p1MaxHP, p2MaxHP;
    public FloatVariable p1Special, p2Special, p1MaxSpecial, p2MaxSpecial;

    private GameObject player1Object, player2Object;
    private FighterController player1, player2;
    private float p1HPPercent, p2HPPercent;
    private float p1DamageCap, p2DamageCap;
    private float p1HPMin = 0, p2HPMin = 0;
    private float currentFightTimer;
    
    
    void Start()
    {
        player1Object = Instantiate(loadArguments.P1FighterType, new Vector3(-5, -4, 0), Quaternion.identity);
        player2Object = Instantiate(loadArguments.P2FighterType, new Vector3(5, -4, 0), Quaternion.identity);

        player1 = player1Object.GetComponent<FighterController>();
        player2 = player2Object.GetComponent<FighterController>();

        p1HP.Value = 100;
        p2HP.Value = 100;

        player1.health = p1HP;
        player2.health = p2HP;

        //p1HP.Value = p1MaxHP.Value;
        //p2HP.Value = p2MaxHP.Value;

        player1.specialMeter = p1Special;
        player2.specialMeter = p2Special;
        player1.maxSpecial = p1MaxSpecial;
        player2.maxSpecial = p2MaxSpecial;

        player1.enemySpecialMeter = p2Special;
        player2.enemySpecialMeter = p1Special;
        player1.enemyMaxSpecial = p2MaxSpecial;
        player2.enemyMaxSpecial = p1MaxSpecial;

        player1.hitParticles = hitParticles;
        player2.hitParticles = hitParticles;

        player1.attack = loadArguments.P1Attack;
        player1.defence = loadArguments.P1Defence;
        player2.attack = loadArguments.P2Attack;
        player2.defence = loadArguments.P2Defence;

        if (loadArguments.isTimedBattle) {
            currentFightTimer = loadArguments.fightDuration;
        }
        else
        {
            timer.enabled = false;
            float damageCapOffset1 = (float)(Math.Sqrt(Math.Abs(player1.defence - player2.attack)) / 10);
            float damageCapOffset2 = (float)(Math.Sqrt(Math.Abs(player2.defence - player1.attack)) / 10);
            if (player1.defence > player2.attack)
            {
                damageCapOffset1 *= -1;
            }
            if (player2.defence > player1.attack)
            {
                damageCapOffset2 *= -1;
            }
            p1DamageCap = .5f + damageCapOffset1;
            p2DamageCap = .5f + damageCapOffset2;

            CalculateHealthPercentages();

            if (p1DamageCap < p1HPPercent) {
                p1HPMin = p1HPPercent - p1DamageCap;
                p1HPBarScript.SetDamageCap(p1HPMin);
            }

            if (p2DamageCap < p2HPPercent) {
                p2HPMin = p2HPPercent - p2DamageCap;
                p2HPBarScript.SetDamageCap(p2HPMin);
            }
        }

    }

    private void Update() 
    {
        if (player1Object.transform.position.x < player2Object.transform.position.x) {
            player1Object.transform.localScale = new Vector3(1, 1, 1);
            player2Object.transform.localScale = new Vector3(-1, 1, 1);
            player1.isFacingRight = true;
            player2.isFacingRight = false;
        }
        else {
            player1Object.transform.localScale = new Vector3(-1, 1, 1);
            player2Object.transform.localScale = new Vector3(1, 1, 1);
            player1.isFacingRight = false;
            player2.isFacingRight = true;
        }

        CalculateHealthPercentages();

        if (p1HPPercent <= 0 || p2HPPercent <= 0) {
            GameOver();
        }

        if (loadArguments.isTimedBattle)
        {
            if (currentFightTimer > 0)
            {
                currentFightTimer -= Time.deltaTime;
            }
            else {
                GameOver();
            }

            timer.text = Math.Ceiling(currentFightTimer).ToString();
        }
        else
        {
            if (p1HPPercent < p1HPMin) {
                p1HPPercent = p1HPMin;
                GameOver();
            }
            else if (p2HPPercent < p2HPMin) {
                p2HPPercent = p2HPMin;
                GameOver();
            }
        }

    }

    private void LateUpdate() 
    {
        if(player1.isFacingRight) {
            cameraScript.updateCamera(player1Object.transform.position.x, player2Object.transform.position.x);
        }
        else {
            cameraScript.updateCamera(player2Object.transform.position.x, player1Object.transform.position.x);
        }
        
    }

    private void GameOver() 
    {
        player1.DisableInput();
        player2.DisableInput();
        roundOver.SetActive(true);
    }

    private void CalculateHealthPercentages()
    {
        p1HPPercent = p1HP.Value / p1MaxHP.Value;
        p2HPPercent = p2HP.Value / p2MaxHP.Value;
    }

}
