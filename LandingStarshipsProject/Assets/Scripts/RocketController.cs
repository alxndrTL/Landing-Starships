using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AgentController))]
[RequireComponent(typeof(PhysicDebugger))]
public class RocketController : MonoBehaviour
{
    public TVCAnimationController tvcac_engine_1;
    public TVCAnimationController tvcac_engine_2;
    public TVCAnimationController tvcac_engine_3;
    public Vector3 centerOfMass;

    private Rigidbody rb;
    private AgentController ac;
    private PhysicDebugger pd;
    private TextController tc;
    private AnimationController anc;
    private EngineParticleController epc;
    private RCSParticleController rpc;
    private LandingSmokeParticleController lspc;
    private EngineRCSAudioController erac;

    bool toReset;
    bool isEngineOn;
    float rollTVC;
    float pitchTVC;
    bool isRollPosRCSOn;
    bool isRollNegRCSOn;
    bool isPitchPosRCSOn;
    bool isPitchNegRCSOn;

    public float height;
    public float init_angle_roll;
    public float init_angle_pitch;
    public float init_xoffset;
    public float init_zoffset;
    public float init_zspeed;
    public float angle_tvc;
    public float thrust_engine;
    public float thrust_rcs;
    public float collision_speed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AgentController>();
        pd = GetComponent<PhysicDebugger>();
        tc = GetComponent<TextController>();
        anc = GetComponent<AnimationController>();
        epc = GetComponent<EngineParticleController>();
        rpc = GetComponent<RCSParticleController>();
        lspc = GetComponent<LandingSmokeParticleController>();
        erac = GetComponent<EngineRCSAudioController>();

        rb.centerOfMass = centerOfMass;
    }

    void FixedUpdate()
    {
        if(ac.episodeFinished)
        {
            return;
        }

        if(toReset)
        {
            rb.position = transform.parent.transform.TransformPoint(new Vector3(Random.Range(-init_xoffset, init_xoffset), height, Random.Range(-init_zoffset, -init_zoffset)));
            rb.velocity = new Vector3(0, 0, init_zspeed);

            rb.rotation = Quaternion.Euler(Random.Range(85, init_angle_pitch), 0, Random.Range(-init_angle_roll, init_angle_roll));
            rb.angularVelocity = Vector3.zero;

            isEngineOn = false;
            rollTVC = 0;
            pitchTVC = 0;
            isRollPosRCSOn = false;
            isRollNegRCSOn = false;
            isPitchPosRCSOn = false;
            isPitchNegRCSOn = false;

            anc.ResetAnimation();

            toReset = false;
            return;
        }

        if (rb.position.y < 1.821 && Mathf.Abs(Vector3.Dot(transform.up, Vector3.right)) < 0.1 && Mathf.Abs(Vector3.Dot(transform.up, Vector3.forward)) < 0.1)
        {
            isRollPosRCSOn = false;
            isRollNegRCSOn = false;
            isPitchPosRCSOn = false;
            isPitchNegRCSOn = false;
        }

        if (isEngineOn)
        {
            Vector3 thrust = new Vector3(0, thrust_engine * Time.deltaTime * 2, 0);

            Quaternion rotation = Quaternion.Euler(pitchTVC, 0, rollTVC);
            Vector3 vectored_thrust = rotation * thrust;

            Vector3 worldForce = transform.TransformVector(vectored_thrust);
            Vector3 worldPoint = transform.TransformPoint(new Vector3(0, -1, 0));

            rb.AddForceAtPosition(worldForce, worldPoint, ForceMode.Force);
            pd.DrawEngineRays(worldForce, worldPoint, thrust_engine / 1000);
        }

        if(isRollPosRCSOn)
        {
            Vector3 thrust_left = new Vector3(thrust_rcs, 0, 0);

            Vector3 worldForce_left_1 = transform.TransformVector(thrust_left);
            Vector3 worldForce_left_2 = transform.TransformVector(thrust_left);

            Vector3 worldPoint_left_1 = transform.TransformPoint(new Vector3(0, 41, 4));
            Vector3 worldPoint_left_2 = transform.TransformPoint(new Vector3(0, 41, -4));

            rb.AddForceAtPosition(worldForce_left_1, worldPoint_left_1, ForceMode.Force);
            rb.AddForceAtPosition(worldForce_left_2, worldPoint_left_2, ForceMode.Force);

            pd.DrawEngineRays(worldForce_left_1, worldPoint_left_1, 1);
            pd.DrawEngineRays(worldForce_left_2, worldPoint_left_2, 1);
        }

        if(isRollNegRCSOn)
        {
            Vector3 thrust_right = new Vector3(-thrust_rcs, 0, 0);

            Vector3 worldForce_right_1 = transform.TransformVector(thrust_right);
            Vector3 worldForce_right_2 = transform.TransformVector(thrust_right);

            Vector3 worldPoint_right_1 = transform.TransformPoint(new Vector3(0, 41, 4));
            Vector3 worldPoint_right_2 = transform.TransformPoint(new Vector3(0, 41, -4));

            rb.AddForceAtPosition(worldForce_right_1, worldPoint_right_1, ForceMode.Force);
            rb.AddForceAtPosition(worldForce_right_2, worldPoint_right_2, ForceMode.Force);

            pd.DrawEngineRays(worldForce_right_1, worldPoint_right_1, 1);
            pd.DrawEngineRays(worldForce_right_2, worldPoint_right_2, 1);
        }

        if (isPitchPosRCSOn)
        {
            Vector3 thrust_left = new Vector3(0, 0, thrust_rcs);

            Vector3 worldForce_left_1 = transform.TransformVector(thrust_left);
            Vector3 worldForce_left_2 = transform.TransformVector(thrust_left);

            Vector3 worldPoint_left_1 = transform.TransformPoint(new Vector3(4, 41, 0));
            Vector3 worldPoint_left_2 = transform.TransformPoint(new Vector3(-4, 41, 0));

            rb.AddForceAtPosition(worldForce_left_1, worldPoint_left_1, ForceMode.Force);
            rb.AddForceAtPosition(worldForce_left_2, worldPoint_left_2, ForceMode.Force);

            pd.DrawEngineRays(worldForce_left_1, worldPoint_left_1, 1);
            pd.DrawEngineRays(worldForce_left_2, worldPoint_left_2, 1);
        }

        if (isPitchNegRCSOn)
        {
            Vector3 thrust_right = new Vector3(0, 0, -thrust_rcs);

            Vector3 worldForce_right_1 = transform.TransformVector(thrust_right);
            Vector3 worldForce_right_2 = transform.TransformVector(thrust_right);

            Vector3 worldPoint_right_1 = transform.TransformPoint(new Vector3(4, 41, 0));
            Vector3 worldPoint_right_2 = transform.TransformPoint(new Vector3(-4, 41, 0));

            rb.AddForceAtPosition(worldForce_right_1, worldPoint_right_1, ForceMode.Force);
            rb.AddForceAtPosition(worldForce_right_2, worldPoint_right_2, ForceMode.Force);

            pd.DrawEngineRays(worldForce_right_1, worldPoint_right_1, 1);
            pd.DrawEngineRays(worldForce_right_2, worldPoint_right_2, 1);
        }

        if (rb.position.y > height + 50 || rb.position.y < -1 || Mathf.Abs(transform.parent.transform.InverseTransformPoint(rb.position).x) > 30 || Mathf.Abs(transform.parent.transform.InverseTransformPoint(rb.position).z) > 100)
        {
            ac.EndEpisode(0);
        }

        if (rb.IsSleeping())
        {
            if (Mathf.Abs(Vector3.Dot(transform.up, Vector3.right)) < 0.1 && Mathf.Abs(Vector3.Dot(transform.up, Vector3.forward)) < 0.1 && Vector3.Dot(transform.up, Vector3.up) > 0.9)
            {
                ac.EndEpisode(1);
            }
            else
            {
                ac.EndEpisode(0);
            }
        }

        //Animations
        if(rb.position.y < 20 && rb.velocity.magnitude > 0.1)
        {
            anc.PlayAnimation();
        }

        rpc.AnimateParticle(isRollPosRCSOn, isRollNegRCSOn, isPitchPosRCSOn, isPitchNegRCSOn);
        epc.AnimateParticle(isEngineOn);
        tc.SetTelemetryText(10*rb.position.y-7, rb.velocity.magnitude);
        lspc.UpdateLandingSmoke(10*rb.position.y-7, isEngineOn);
        erac.isEngineOn = isEngineOn;
        tvcac_engine_1.UpdateTVCAnimation(rollTVC, pitchTVC);
        tvcac_engine_2.UpdateTVCAnimation(rollTVC, pitchTVC);
        tvcac_engine_3.UpdateTVCAnimation(rollTVC, pitchTVC);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "AgentRocket" || ac.episodeFinished)
        {
            return;
        }

        if (collision.relativeVelocity.y > collision_speed)
        {
            ac.EndEpisode(0);
        }
    }

    public void ResetPosition()
    {
        toReset = true;
    }

    public Vector3 GetPosition()
    {
        return transform.parent.transform.InverseTransformPoint(rb.position);
    }

    public Vector3 GetVelocity()
    {
        return rb.velocity;
    }

    public Vector3 GetAngularVelocity()
    {
        return rb.angularVelocity;
    }

    public float GetPitchRotation()
    {
        return Vector3.Dot(transform.up, Vector3.forward);
    }

    public float GetUpsideDownRotation()
    {
        return Vector3.Dot(transform.up, Vector3.up);
    }

    public float GetRollRotation()
    {
        return Vector3.Dot(transform.up, Vector3.right);
    }

    public void ModifyEngineState(int throttleConsigne, int rollTVCConsigne, int pitchTVCConsigne)
    {
        if(throttleConsigne == 0)
        {
            isEngineOn = false;
            rollTVC = 0;
            pitchTVC = 0;
        }else
        {
            isEngineOn = true;

            if(rollTVCConsigne == 0)
            {
                rollTVC = 0;
            }else if(rollTVCConsigne == 1)
            {
                rollTVC = -angle_tvc;
            }else if(rollTVCConsigne == 2)
            {
                rollTVC = angle_tvc;
            }

            if(pitchTVCConsigne == 0)
            {
                pitchTVC = 0;
            }else if(pitchTVCConsigne == 1)
            {
                pitchTVC = -angle_tvc;
            }else if(pitchTVCConsigne == 2)
            {
                pitchTVC = angle_tvc;
            }
        }
    }

    public void ModifyRollRCSState(int consigne)
    {
        if(consigne == 1)
        {
            isRollPosRCSOn = true;
            isRollNegRCSOn = false;
        }else if(consigne == 2)
        {
            isRollPosRCSOn = false;
            isRollNegRCSOn = true;
        }
        else
        {
            isRollPosRCSOn = false;
            isRollNegRCSOn = false;
        }
    }

    public void ModifyPitchRCSState(int consigne)
    {
        if (consigne == 1)
        {
            isPitchPosRCSOn = true;
            isPitchNegRCSOn = false;
        }
        else if (consigne == 2)
        {
            isPitchPosRCSOn = false;
            isPitchNegRCSOn = true;
        }
        else
        {
            isPitchPosRCSOn = false;
            isPitchNegRCSOn = false;
        }
    }
}
