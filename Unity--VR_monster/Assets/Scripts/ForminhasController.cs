using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForminhasController : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    public void onGraspBegin()
    {
        animator.SetBool("isGrabbed", true);
    }

    public void onGraspEnd()
    {
        animator.SetBool("isGrabbed", false);
    }
}
