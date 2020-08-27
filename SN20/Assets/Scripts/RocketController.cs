using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AgentController))]
[RequireComponent(typeof(PhysicDebugger))]
public class RocketController : MonoBehaviour
{
    [Range(0, 10000)] public float throttle;
    public ColorizePlane colorizePlane;
    public Vector3 centerOfMass;

    private Rigidbody rb;
    private AgentController ac;
    private PhysicDebugger pd;

    bool toReset;
    bool isEngineOn;
    float rollTVC;
    float pitchTVC;
    bool isRollPosRCSOn;
    bool isRollNegRCSOn;
    bool isPitchPosRCSOn;
    bool isPitchNegRCSOn;

    /*
    public float height;
    public float x_offset;
    public float z_offset;
    public float angle;
    public float z_init_speed;
    public float TVCangle;
    public float rcs_thurst;
    public float engine_thrust;
    public float landing_speed;
    */

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

        rb.centerOfMass = centerOfMass;

        /*
        height = 50;
        x_offset = 4;
        z_offset = 4;
        angle = 90;
        z_init_speed = 1;
        TVCangle = 5.0f;
        rcs_thurst = 2.5f;
        engine_thrust = 5000;
        landing_speed = 5;
        */

        height = 50;
        init_angle_roll = 0;
        init_angle_pitch = 0;
        init_xoffset = 0;
        init_zoffset = 0;
        init_zspeed = 0;
        angle_tvc = 5;
        thrust_engine = 4000;
        thrust_rcs = 2.5f;
        collision_speed = 5;
}

    void FixedUpdate()
    {
        if(toReset)
        {

            /*
            height = 550;
            init_angle_roll = 5;
            init_angle_pitch = 90;
            init_xoffset = 15;
            init_zoffset = 90;
            init_zspeed = 1;
            angle_tvc = 7;
            thrust_engine = 5000;
            thrust_rcs = 0.2f;
            collision_speed = 5;
            */

            rb.position = transform.parent.transform.TransformPoint(new Vector3(Random.Range(-init_xoffset, init_xoffset), height, Random.Range(-init_zoffset, init_zoffset)));
            rb.velocity = new Vector3(0, 0, init_zspeed);

            rb.rotation = Quaternion.Euler(Random.Range(-init_angle_pitch, init_angle_pitch), 0, Random.Range(-init_angle_roll, init_angle_roll)); //Attention pour le angle pitch on voudra par la suite juste 90 mais d'un cote
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
            Vector3 thrust = new Vector3(0, 2 * thrust_engine * Time.deltaTime, 0);

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

        //pas ouf
        //float alt = rb.position.y;
        //Debug.Log((int) alt + "U |" + "predicted using vel" + (int) (alt - rb.velocity.y * Time.deltaTime) + "U |" + rb.velocity.magnitude + "U/s");

        //super
        //float alt = 10*rb.position.y;
        //Debug.Log((int)alt + "m |" + "predicted using vel" + (int)(alt - rb.velocity.y * Time.deltaTime) + "m |" + rb.velocity.magnitude + "m/s");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "AgentRocket")
        {
            return;
        }

        if (collision.relativeVelocity.y > collision_speed)
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

    public float GetXRotation()
    {
        return Vector3.Dot(transform.up, Vector3.forward);
    }

    public float GetYRotation()
    {
        return Vector3.Dot(transform.up, Vector3.up);
    }

    public float GetZRotation()
    {
        return Vector3.Dot(transform.up, Vector3.right);
    }

    public void ModifyEngineState(int throttleConsigne, int rollTVCConsigne, int pitchTVCConsigne)
    {
        /*
        if(consigne == 1)
        {
            isEngineOn = true;
        }
        else
        {
            isEngineOn = false;
        }
        */

        /*
        if(consigne == 0)
        {
            isEngineOn = false;
            TVC = 0;
        }else if(consigne == 1)
        {
            isEngineOn = true;
            TVC = 0;
        }else if(consigne == 2)
        {
            isEngineOn = true;
            TVC = -5;
        }
        else
        {
            isEngineOn = true;
            TVC = 5;
        }
        */

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
                rollTVC = +angle_tvc;
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

    /*
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
            isRollPosRCSOn = false;
            isPitchNegRCSOn = false;
        }
    }
    */

}
