using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFactory
{

    public static IEffect GetEffect() {

        int random = Random.Range(0, 100);

        if (random < 2)
        {
            return new PowerBallMass();
        }

        if (random < 4)
        {
            return new IncreasePlayerSpeed();
        }

        if (random < 6)
        {
            return new PlayerFire();
        }

        if (random < 8)
        {
            return new BallMass();
        }

        if (random < 10)
        {
            return new SlowSpeed();
        }

        if (random < 12)
        {
            return new TripleBall();
        }


        return null;
    }
}
