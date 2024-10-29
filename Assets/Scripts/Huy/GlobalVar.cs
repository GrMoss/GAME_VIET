using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar : MonoBehaviour
{
    public static string GlobalName;
    
    void Start()
    {
        if(PlayerPrefs.GetString("GlobalName") == null)
        {
            PlayerPrefs.SetString("GlobalName","Long");
        }
    }

    public void SetNamePlayer(string name)
    {
        PlayerPrefs.SetString("GlobalName", name);
    }

    public void GetNamePlayer()
    {
        PlayerPrefs.GetString("GlobalName");
    }
}
