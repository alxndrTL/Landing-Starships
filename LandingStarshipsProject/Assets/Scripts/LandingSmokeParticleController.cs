using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingSmokeParticleController : MonoBehaviour
{
    public ParticleSystem LANDING_SMOKE;

    public void UpdateLandingSmoke(float altitude, bool isEngineOn)
    {
        if(LANDING_SMOKE)
        {
            if (altitude < 400)
            {
                if (isEngineOn)
                {
                    var em = LANDING_SMOKE.emission;
                    em.rateOverTime = (-2.5f * altitude + 1000);

                    LANDING_SMOKE.Play();
                }
            }
        }
    }
}
