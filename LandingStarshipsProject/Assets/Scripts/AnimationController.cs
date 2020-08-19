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
            anim.Play("LandingLegsDeploy");
            hasDeployed = true;
        }   
    }
}
