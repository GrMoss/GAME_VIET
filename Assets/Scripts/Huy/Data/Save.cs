using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Save : MonoBehaviour 
{
    public void ButtonSave()
    {
        Debug.Log("IsWork1");
        Player.Instance.SavePlayer(); 
    }

     public void ButtonLoad()
    {
        Debug.Log("IsWork2");
        Player.Instance.DisplayAllPlayers();
        Debug.Log(Application.persistentDataPath);
    }
}