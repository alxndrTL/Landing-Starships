using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RCSParticleController : MonoBehaviour
{
    public ParticleSystem RCS_ROLL_POS_1;
    public ParticleSystem RCS_ROLL_POS_2;
    public ParticleSystem RCS_ROLL_NEG_1;
    public ParticleSystem RCS_ROLL_NEG_2;

    public ParticleSystem RCS_PITCH_POS_1;
    public ParticleSystem RCS_PITCH_POS_2;
    public ParticleSystem RCS_PITCH_NEG_1;
    public ParticleSystem RCS_PITCH_NEG_2;

    public void AnimateParticle(bool isRollPosRCSOn, bool isRollNegRCSOn, bool isPitchPosRCSOn, bool isPitchNegRCSOn)
    {
        if(isRollPosRCSOn)
        {
            RCS_ROLL_POS_1.Play();
            RCS_ROLL_POS_2.Play();
        }

        if(isRollNegRCSOn)
        {
            RCS_ROLL_NEG_1.Play();
            RCS_ROLL_NEG_1.Play();
        }
        
        if(isPitchPosRCSOn)
        {
            RCS_PITCH_POS_1.Play();
            RCS_PITCH_POS_2.Play();
        }
        
        if(isPitchNegRCSOn)
        {
            RCS_PITCH_NEG_1.Play();
            RCS_PITCH_NEG_2.Play();
        }
    }
}
