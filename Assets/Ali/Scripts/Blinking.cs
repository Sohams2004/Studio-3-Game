using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blinking : MonoBehaviour
{
     public Animator animator; 
    public string parameterName; 
    public float delayToBlink = 5f; 

    void Start()
    {
        
        StartCoroutine(PlayAnimationAfterDelayCoroutine());
    }

    IEnumerator PlayAnimationAfterDelayCoroutine()
    {
        yield return new WaitForSeconds(delayToBlink);

        animator.SetTrigger(parameterName);
    }
}
