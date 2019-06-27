using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Envia a velocidade de um Rigid Body para um float em um Animator.
/// 
/// Uso:
/// - Configure os campos rv e animator
/// - Coloque o nome do float que você criou o State Machine do Animator.
/// </summary>
public class SpeedDetector : MonoBehaviour
{
    /// <summary>
    /// Rigid Body do objeto que se move.
    /// </summary>
    public Rigidbody rb;
    /// <summary>
    /// Animator desse objeto.
    /// </summary>
    public Animator animator;
    /// <summary>
    /// Nome do float criado no Animator
    /// </summary>
    public string floatName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rb.velocity.magnitude;
        animator.SetFloat(floatName, speed);
    }
}
