using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public Animator animator;
    public GameComplete gameComplete;
    
    public void TriggerFlipCard()
    {
        animator.SetTrigger("Flip");
    }
    public void CloseCard()
    {
        animator.SetTrigger("Close");
    }

    public void CloseObject()
    {
        gameObject.SetActive(false);
    }
    
    public void ClosePrize()
    {
        gameComplete.ClosePrize();
    }
}
