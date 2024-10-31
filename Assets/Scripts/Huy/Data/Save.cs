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
        Player.Instance.positionPlayer[0] = transform.position.x;
        Player.Instance.positionPlayer[1] = transform.position.y;
        Player.Instance.positionPlayer[2] = transform.position.z;
    }

     public void ButtonLoad()
    {
        Debug.Log("IsWork2");
        Player.Instance.DisplayAllPlayers();
        Debug.Log(Application.persistentDataPath);
    }
}