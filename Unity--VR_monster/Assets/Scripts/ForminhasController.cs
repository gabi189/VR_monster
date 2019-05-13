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
        //descobrir se o game object está se movendo
        // EEE se ele não está sendo grabbed 
        //if (isGrabbed == false) ???
        //animator.SetBool("isRunning", true); 
    }

    public void onGraspBegin()
    {
        animator.SetBool("isGrabbed", true);
        rigidbody.constraints = RigidbodyConstraints.None;

        //FollowScript.forgetTarget;

    }

    public void onGraspEnd()
    {
        animator.SetBool("isGrabbed", false);

        rigidbody.constraints &= RigidbodyConstraints.FreezeRotationX;
        rigidbody.constraints &= RigidbodyConstraints.FreezeRotationZ;
        
    }


}
