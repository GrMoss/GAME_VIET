using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    private void FixedUpdate() 
    {
             Debug.Log(PlayerPrefs.GetString("GlobalName"));
    }
     public void ButtonPlay()
     {
         SceneManager.LoadScene("Home");
     }

     public void Exit()
     {
         Application.Quit();
     }

     public void ExitToMenu()
     {
         SceneManager.LoadScene("Login");
     }
     
     public void ExitToHome()
     {
         SceneManager.LoadScene("Home");
         Time.timeScale = 1;
     }
 
     public void MiniGameDiCaKheo()
     {
         SceneManager.LoadScene("DiCaKheo");
     }
}
