using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation2 : MonoBehaviour
{
    public Animator animator;
    public GameComplete2 gameComplete2;
    
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
        gameComplete2.ClosePrize();
    }
}
