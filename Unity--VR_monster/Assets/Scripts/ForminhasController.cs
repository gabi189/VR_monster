using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForminhasController : MonoBehaviour
{
    //Rigidbody rigidbody;
    public bool isGrounded;
    bool isGrabbed;
    Animator animator;


    public AudioClip impacto;
    public AudioClip levantado;
    public AudioClip hover;
    public AudioClip segurado;
    public AudioClip susto;
    public AudioClip grito;


    private AudioSource source;
    private float lowPitchRange = .75F;
    private float highPitchRange = 1.5F;
    private float velToVol = .2F;
    private float velocityClipSplit = 10F;


    void Awake()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        
    }


    void Update()
    {
        //descobrir se o game object está se movendo
        // EEE se ele não está sendo grabbed //if (isGrabbed == false) ???
        //animator.SetBool("isRunning", true); 

        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 8
            && !isGrounded)
        {
            isGrounded = true;
            source.PlayOneShot(impacto, 0.2F);
        }

        if (collision.gameObject.layer == 12  // Layer "Forminha"
            || collision.gameObject.layer == 13)  //Layer "Maos"
        {
            source.PlayOneShot(impacto, 0.2F);
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 8
            && isGrounded)
        {
            isGrounded = false;
            source.PlayOneShot(levantado, 0.2F);
        }
    }

    public void onGraspBegin()
    {
        isGrabbed = true;
        animator.SetBool("isGrabbed", true);
        source.clip = segurado;
        source.Play(1); //delay de 1 segundo antes de das play no audio source
        
        //source.PlayOneShot(segurado, 1);
        //desligar o TargetFollower, o look at target e o stay upwards
    }

    public void onGraspEnd()
    {
        isGrabbed = false;
        animator.SetBool("isGrabbed", false);
        source.Pause();

        //audioSource.Pause(graspSound);
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
