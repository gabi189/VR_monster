using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    public Transform target;

    public float elasticConstant = 0.5f;
    public float damping = 0.1f;
    public float maximumTorqueToApply = 200;

    public float minAngleToFollow = 3;

    public bool nullVerticalError = true;

    Rigidbody rb;

    float angle = 0;
    float lastAngle = 0;

    float aux;
    float timeToReachMaximumTorque = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (aux < 1)
        {
            aux += Time.deltaTime / timeToReachMaximumTorque;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 delta = (target.position - this.transform.position);
        //float distanceProjectedIntoXZPlane = new Vector3(delta.x,0f, delta.z).magnitude;
        //if (distanceProjectedIntoXZPlane < 0.1f)
        //    return;

        Vector3 positionError = target.position - this.transform.position;

        if (nullVerticalError)
            positionError = new Vector3(positionError.x, 0f, positionError.z);

        angle = Vector3.SignedAngle(positionError, this.transform.forward,Vector3.up);

        if (Mathf.Abs(angle) > minAngleToFollow)
            ApplyElasticForce();

        lastAngle = angle;
    }

    void ApplyElasticForce()
    {
        //float angle = Vector3.SignedAngle((target.position - this.transform.position), this.transform.forward, Vector3.up);

        Vector3 torque = - this.transform.up * (angle * elasticConstant + (angle - lastAngle) / Time.fixedDeltaTime * damping);

        if (torque.magnitude > maximumTorqueToApply)
            torque = torque.normalized * maximumTorqueToApply;

        rb.AddTorque(torque);
    }

    private void OnEnable()
    {
        aux = 0f;
    }
}
