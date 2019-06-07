using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForminhasController : MonoBehaviour
{
    //Rigidbody rigidbody;
    Animator animator;
    AudioSource audioSource;

    public AudioClip graspSound;


    void Start()
    {
        //rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();   
        audioSource = GetComponent<AudioSource>();
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
        audioSource.Play(graspSound, 44100); //delay de 1 segundo antes de das play no audio source

        //desligar o TargetFollower, o look at target e o stay upwards

    }

    public void onGraspEnd()
    {
        animator.SetBool("isGrabbed", false);
        audioSource.Pause(graspSound);
        //ligar o TargetFollower, o look at target e o stay upwards

    }

    public void onHoverBegin()
    {
        animator.SetBool("onHover", true);

        //float vol = Random.Range(volLowRange, volHighRange);
        //source.Play();
    }

    public void onHoverEnd()
    {
        animator.SetBool("onHover", false);
    }

}
