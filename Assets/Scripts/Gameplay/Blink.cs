using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;
using TMPro;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public bool canMove = false;
    public float minBlinkTime = 1f, maxBlinkTime = 3f;
    public float minStareTime = 3f, maxStareTime = 6f;
    public bool looping = true;

    public Animator eyeAnimator;

    private void Start()
    {
        StartCoroutine(Blinking());
    }

    IEnumerator Blinking()
    {
        while (looping == true)
        {
            canMove = false;
            
            eyeAnimator.SetTrigger("Open");
            Debug.Log("Open");
            yield return new WaitForSeconds(0.3f);
            
            eyeAnimator.SetTrigger("IdleEyes");
            float stareTime = UnityEngine.Random.Range(minStareTime, maxStareTime);
            yield return new WaitForSeconds(stareTime);
            Debug.Log("Keep Open");

            canMove = true;
            eyeAnimator.SetTrigger("Close");
            Debug.Log("Closed");
            yield return new WaitForSeconds(0.3f);
            
            eyeAnimator.SetTrigger("KeepClosed");
            float blinkTime = UnityEngine.Random.Range(minBlinkTime, maxBlinkTime);
            yield return new WaitForSeconds(blinkTime);
            Debug.Log("Keep Closed");
        }
    }
    
    
}    
