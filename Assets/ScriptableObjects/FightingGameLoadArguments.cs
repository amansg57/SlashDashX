using UnityEngine;

[CreateAssetMenu(fileName = "FightingGameLoadArguments", menuName = "2D Fighting/FightingGameLoadArguments", order = 0)]
public class FightingGameLoadArguments : ScriptableObject
{
    public int P1Attack, P2Attack, P1Defence, P2Defence;
    public GameObject P1FighterType, P2FighterType;
    public bool isTimedBattle;
    public float fightDuration;
}