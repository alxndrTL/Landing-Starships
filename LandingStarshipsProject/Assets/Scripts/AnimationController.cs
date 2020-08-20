using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationController : MonoBehaviour
{
    private Animation anim;
    bool hasDeployed;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    public void PlayAnimation()
    {
        if(!hasDeployed)
        {
            anim["LandingLegsDeploy"].speed = 1;
            anim.Play("LandingLegsDeploy");
            hasDeployed = true;
        }   
    }

    public void ResetAnimation()
    {
        anim["LandingLegsDeploy"].speed = -1;
        anim.Play("LandingLegsDeploy");
        hasDeployed = false;
    }
}
