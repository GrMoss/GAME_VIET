using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InputLogin : MonoBehaviour
{
    [SerializeField] TMP_InputField inputFieldName;
    [SerializeField] Button ButtonStar;
    private int Gender; // 0 cho nam, 1 cho nữ

    public void GetGender(int gender)
    {
        Gender = gender;
    }

    private void FixedUpdate() 
    {
        ButtonStar.interactable = !string.IsNullOrEmpty(inputFieldName.text.Trim());
    }

    public void SetDataLogin()
    {
        SetNamePlayer(inputFieldName.text);
        Player.Instance.gender = Gender;
        Player.Instance.GenerateRandomId();
    }
    
    public void SetNamePlayer(string name)
    {
        Player.Instance.playerName = name;
    }
}