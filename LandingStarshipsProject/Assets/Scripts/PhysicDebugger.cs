using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PhysicDebugger : MonoBehaviour
{
    protected Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmos()
    {
        if (rb)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + transform.rotation * rb.centerOfMass, 0.1f);
        }
    }

    public void DrawEngineRays(Vector3 worldForce, Vector3 worldPointApplication, float scale)
    {
        Debug.DrawRay(worldPointApplication, worldForce.normalized * -1 * 2, Color.red);
    }
}
