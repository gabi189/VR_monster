using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Dispara Unity Events configuráveis no inspetor quando acontece um colisão com o Trigger.
/// 
/// Uso:
/// - No game object com o script, coloque um colisor e marque a caixa "Is Trigger".
/// - Por segurança, coloque um Rigid Body no Game Object e marque a Caixa "Is Kinematic" 
/// (O unity só detecta colisão quando pelo menos um objeto tem Rigid Body).
/// - Configure que Layers você que INCLUIR na detecção da colisão
/// - Configure que Game Objects vc quer IGNORAR.
/// - Crie os eventos que quiser nos inspector.
/// </summary>
[RequireComponent(typeof(Collider))]
public class TriggerCollisionDetector : MonoBehaviour
{
    [Header("Configuration")]
    public LayerMask whatLayersToDetect;
    public List<GameObject> gameObjectsToIgnore;

    [Header("Events")]
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerStay;
    public UnityEvent onTriggerExit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Retorna Falso caso detecção deva ser ignorada.
    /// </summary>
    /// <param name="go">Game Object com o qual o ocorreu a colisão.</param>
    /// <returns>True, se deteccção deve ser ignorda. False, caso contrário</returns>
    bool ShouldIgnoreDetection(GameObject go)
    {
        //If it is not in Layer Mask
        if (whatLayersToDetect != (whatLayersToDetect | (1 << go.layer)))
            return true;

        //If it is in Game Objects to Ignore
        if (gameObjectsToIgnore.Contains(go))
            return true;


        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ShouldIgnoreDetection(other.gameObject))
            return;

        onTriggerEnter.Invoke();
        //print("Enter");
    }

    private void OnTriggerStay(Collider other)
    {
        if (ShouldIgnoreDetection(other.gameObject))
            return;

        onTriggerStay.Invoke();
        //print("Stay");
    }

    private void OnTriggerExit(Collider other)
    {
        if (ShouldIgnoreDetection(other.gameObject))
            return;

        onTriggerExit.Invoke();
        //print("Exit");
    }
}
