using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimPlayerOnStick : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public float wait = 0.3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("T"))
        {
            animator.SetBool("T",true);
            StartCoroutine(Wait());
        }

        if (other.CompareTag("CB_L"))
        {
            animator.SetBool("CB_L",true);
        }
        
        if (other.CompareTag("CB_R"))
        {
            animator.SetBool("CB_R",true);
        }
        
        if (other.CompareTag("GT_L"))
        {
            animator.SetBool("GT_L",true);
        }
        
        if (other.CompareTag("GT_R"))
        {
            animator.SetBool("GT_R",true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Time.timeScale != 0)
        {
            if (other.CompareTag("CB_L"))
            {
                animator.SetBool("CB_L",false);
            }
        
            if (other.CompareTag("CB_R"))
            {
                animator.SetBool("CB_R",false);
            }
        
            if (other.CompareTag("GT_L"))
            {
                animator.SetBool("GT_L",false);
            }
        
            if (other.CompareTag("GT_R"))
            {
                animator.SetBool("GT_R",false);
            }
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(wait);
        Time.timeScale = 0;
    }
}
