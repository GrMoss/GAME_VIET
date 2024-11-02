using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimPlayerOnStick : MonoBehaviour
{
    public Animator[] animator;
    public GameComplete gameComplete;
    public GameObject gameOverPanerl;
      public PointDiCaKheo pointDiCaKheo;
    public float wait = 0.3f;
    int characterIndex = Player.Instance.gender;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("T"))
        {
            animator[characterIndex].SetBool("T",true);
            StartCoroutine(Wait());
        }

        if (other.CompareTag("CB_L"))
        {
            animator[characterIndex].SetBool("CB_L",true);
        }
        
        if (other.CompareTag("CB_R"))
        {
            animator[characterIndex].SetBool("CB_R",true);
        }
        
        if (other.CompareTag("GT_L"))
        {
            animator[characterIndex].SetBool("GT_L",true);
        }
        
        if (other.CompareTag("GT_R"))
        {
            animator[characterIndex].SetBool("GT_R",true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (Time.timeScale != 0)
        {
            if (other.CompareTag("CB_L"))
            {
                animator[characterIndex].SetBool("CB_L",false);
            }
        
            if (other.CompareTag("CB_R"))
            {
                animator[characterIndex].SetBool("CB_R",false);
            }
        
            if (other.CompareTag("GT_L"))
            {
                animator[characterIndex].SetBool("GT_L",false);
            }
        
            if (other.CompareTag("GT_R"))
            {
                animator[characterIndex].SetBool("GT_R",false);
            }
        }
        
    }

    IEnumerator Wait()
    {
        StartVibration();
        yield return new WaitForSeconds(wait);
        gameComplete.isSuccess = false;
        gameOverPanerl.SetActive(true);
        pointDiCaKheo.SetActiveOJController(false);
    }

    public void StartVibration()
    {
        Handheld.Vibrate();
        StartCoroutine(VibrationCoroutine());
    }

    private IEnumerator VibrationCoroutine()
    {
        yield return new WaitForSeconds(0.02f);
    }
}
