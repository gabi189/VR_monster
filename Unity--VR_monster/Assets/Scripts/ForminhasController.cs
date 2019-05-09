using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForminhasController : MonoBehaviour
{
    Rigidbody rigidbody;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    public void onGraspBegin()
    {
        animator.SetBool("isGrabbed", true);
        rigidbody.constraints = RigidbodyConstraints.None;
        print("oi");
    }

    public void onGraspEnd()
    {
        animator.SetBool("isGrabbed", false);

        rigidbody.constraints &= RigidbodyConstraints.FreezeRotationX;
        rigidbody.constraints &= RigidbodyConstraints.FreezeRotationZ;
        print("tchau");
    }
}
