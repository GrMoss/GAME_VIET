using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    [SerializeField]
    private CharaterData charaterData;

    [SerializeField]
    private Animator animator;

    private void Awake() 
    {
        // Thiết lập nhân vật ban đầu
        ChangeCharacter(Player.Instance.gender);
    }

    private void Start() 
    {
         ChangeCharacter(Player.Instance.id);
    }
    public void ChangeCharacter(int gender)
    {
        Charater charater = charaterData.GetCharater(gender);
        if (charater != null && charater.animatorController != null)
        {
            animator.runtimeAnimatorController = charater.animatorController;
            Debug.Log("AnimatorController changed for character ID: " + gender);
        }
        else
        {
            Debug.LogWarning("Character or AnimatorController not found for ID: " + gender);
        }
    }
}