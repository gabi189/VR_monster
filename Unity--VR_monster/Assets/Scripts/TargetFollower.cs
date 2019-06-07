using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFollower : MonoBehaviour
{
    public Transform target;

    public float elasticConstant = 10f;
    public float damping =  7f;
    public float maximumForceToApply = 100f;

    public float minDistanceToFollow = 0.4f;

    public bool nullVerticalError = true;

    Rigidbody rb;

    Vector3 positionError = Vector3.zero;
    Vector3 lastPositionError = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        positionError = target.position - this.transform.position;

        if (nullVerticalError)
            positionError = new Vector3(positionError.x, 0f, positionError.z);

        if (positionError.magnitude > minDistanceToFollow)
            ApplyElasticForce();

        lastPositionError = positionError;
    }


    void ApplyElasticForce()
    {
        Vector3 force = positionError * elasticConstant + (positionError - lastPositionError) / Time.fixedDeltaTime * damping;

        if (force.magnitude > maximumForceToApply)
            force = force.normalized * maximumForceToApply;
        
        rb.AddForce(force);
    }
}
