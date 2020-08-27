using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationController : MonoBehaviour
{

    private Animation anim;

    void Start()
    {
        anim = GetComponent<Animation>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.Play("LandingLegsDeploy");
        }
    }
}
