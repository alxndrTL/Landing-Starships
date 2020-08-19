using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AgentController))]
[RequireComponent(typeof(PhysicDebugger))]
public class RocketController : MonoBehaviour
{
    public ColorizePlane colorizePlane;
    public Vector3 centerOfMass;

    private Rigidbody rb;
    private AgentController ac;
    private PhysicDebugger pd;
    private TextController tc;
    private AnimationController anc;
    private EngineParticleController epc;
    private RCSParticleController rpc;
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
    public float z_offset;
    public float pitch_init_angle;
    public float z_init_speed;
    public float TVCangle;
    public float rcs_thurst;
    public float engine_thrust;
    public float x_offset = 15;
    public float roll_init_angle = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ac = GetComponent<AgentController>();
        pd = GetComponent<PhysicDebugger>();
        tc = GetComponent<TextController>();
        anc = GetComponent<AnimationController>();
        epc = GetComponent<EngineParticleController>();
        rpc = GetComponent<RCSParticleController>();
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
            rb.position = transform.parent.transform.TransformPoint(new Vector3(Random.Range(-x_offset, x_offset), height, Random.Range(-z_offset, -z_offset)));
            rb.velocity = new Vector3(0, 0, z_init_speed);

            rb.rotation = Quaternion.Euler(Random.Range(85, pitch_init_angle), 0, Random.Range(-roll_init_angle, roll_init_angle));
            rb.angularVelocity = Vector3.zero;

            isEngineOn = false;
            rollTVC = 0;
            pitchTVC = 0;
            isRollPosRCSOn = false;
            isRollNegRCSOn = false;
            isPitchPosRCSOn = false;
            isPitchNegRCSOn = false;

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
            Vector3 thrust = new Vector3(0, engine_thrust * Time.deltaTime * 2, 0);

            Quaternion rotation = Quaternion.Euler(pitchTVC, 0, rollTVC);
            Vector3 vectored_thrust = rotation * thrust;

            Vector3 worldForce = transform.TransformVector(vectored_thrust);
            Vector3 worldPoint = transform.TransformPoint(new Vector3(0, -1, 0));

            rb.AddForceAtPosition(worldForce, worldPoint, ForceMode.Force);
            pd.DrawEngineRays(worldForce, worldPoint, engine_thrust / 1000);
        }

        if(isRollPosRCSOn)
        {
            Vector3 thrust_left = new Vector3(rcs_thurst, 0, 0);

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
            Vector3 thrust_right = new Vector3(-rcs_thurst, 0, 0);

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
            Vector3 thrust_left = new Vector3(0, 0, rcs_thurst);

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
            Vector3 thrust_right = new Vector3(0, 0, -rcs_thurst);

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
            colorizePlane.Colorize(Color.red);
            ac.EndEpisode(0);
        }

        if (rb.IsSleeping())
        {
            if (Mathf.Abs(Vector3.Dot(transform.up, Vector3.right)) < 0.1 && Mathf.Abs(Vector3.Dot(transform.up, Vector3.forward)) < 0.1 && Vector3.Dot(transform.up, Vector3.up) > 0.9)
            {
                colorizePlane.Colorize(Color.green);
                ac.EndEpisode(1);
            }
            else
            {
                colorizePlane.Colorize(Color.red);
                ac.EndEpisode(0);
            }
        }

        //Animations
        if(rb.position.y < 20)
        {
            anc.PlayAnimation();
        }

        rpc.AnimateParticle(isRollPosRCSOn, isRollNegRCSOn, isPitchPosRCSOn, isPitchNegRCSOn);
        epc.AnimateParticle(isEngineOn);
        tc.SetTelemetryText(10*rb.position.y-7, rb.velocity.magnitude);
        erac.isEngineOn = isEngineOn;
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "AgentRocket" || ac.episodeFinished)
        {
            return;
        }

        if (collision.relativeVelocity.y > 5)
        {
            colorizePlane.Colorize(Color.red);
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
                rollTVC = -TVCangle;
            }else if(rollTVCConsigne == 2)
            {
                rollTVC = +TVCangle;
            }

            if(pitchTVCConsigne == 0)
            {
                pitchTVC = 0;
            }else if(pitchTVCConsigne == 1)
            {
                pitchTVC = -TVCangle;
            }else if(pitchTVCConsigne == 2)
            {
                pitchTVC = TVCangle;
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
