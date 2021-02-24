using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerAttackManager : AttackManager
{

    public override void StandingLAtk(int attack)
    {
        hitBoxScript.setParameters(DamageCalc(5, attack), 2.5f, 16, 12, false);
    }

    public override void StandingMAtk(int attack)
    {
        hitBoxScript.setParameters(DamageCalc(8, attack), 3.5f, 20, 16, false);
    }

    public override void StandingHAtk(int attack)
    {
        hitBoxScript.setParameters(DamageCalc(13, attack), 5f, 30, 16, false);
    }

    public override void JumpingLAtk(int attack)
    {
        hitBoxScript.setParameters(DamageCalc(5, attack), 2.5f, 16, 12, false);
    }
    
    public override void JumpingMAtk(int attack)
    {

    }

    public override void JumpingHAtk(int attack)
    {
        hitBoxScript.setParameters(DamageCalc(13, attack), 3f, 30, 16, false);
    }

    public override void DashAtk(int attack)
    {
        hitBoxScript.setParameters(DamageCalc(7, attack), 1f, 12, 10, false);
    }

}
