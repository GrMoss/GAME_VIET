using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputName : MonoBehaviour
{
    [SerializeField] TMP_InputField inputFieldName;

      void Start()
    {
        PlayerPrefs.SetString("GlobalName","");
    }
    
    private void FixedUpdate() 
    {
        SetNamePlayer(inputFieldName.text);
    }

   public void SetNamePlayer(string name)
   {
        PlayerPrefs.SetString("GlobalName", name);
   }
}
