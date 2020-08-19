using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineParticleController : MonoBehaviour
{
    public ParticleSystem ENGINE_PARTICLESYSTEM;

    public void AnimateParticle(bool isEngineOn)
    {
        if(isEngineOn)
        {
            ENGINE_PARTICLESYSTEM.Play();
        }
    }
}
