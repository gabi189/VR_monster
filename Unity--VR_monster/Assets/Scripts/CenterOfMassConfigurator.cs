using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterOfMassConfigurator : MonoBehaviour
{
    public Vector3 centerOfMass = Vector3.down * 0.5f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnEnable()
    {
        rb.centerOfMass = centerOfMass;
    }
}
