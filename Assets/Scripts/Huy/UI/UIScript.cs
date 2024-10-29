using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
  
    public TMP_Text textName;

    private void Start() {
        textName.text = PlayerPrefs.GetString("GlobalName");   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
