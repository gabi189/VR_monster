﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Intro;
    public GameObject TmIdle1;
    public float tempo1;

    private bool isCoroutineExecuting = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteAfterTime(tempo1));
        TmIdle1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
             
    }

    
    // Essa seria a segunda timeline a ser tocada
    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;
        print("oi");

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        //print("delay");
        TmIdle1.SetActive(true);
        isCoroutineExecuting = false;
    }
    
}
