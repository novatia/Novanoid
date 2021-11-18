using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory
{

    public static IEffect GetEffect() {

        int random = Random.Range(0, 12);

        if (random < 4)
        {
            return new PowerBallMass();
        }

        if (random < 8)
        {
            return new IncreasePlayerSpeed();
        }

        if (random < 12)
        {
            return new PlayerFire();
        }

        return null;
    }
}
