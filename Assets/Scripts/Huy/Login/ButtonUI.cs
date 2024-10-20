using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
 public void ButtonPlay()
 {
     SceneManager.LoadScene("Home");
 }

 public void Exit()
 {
     Application.Quit();
 }

 public void ExitMenu()
 {
     SceneManager.LoadScene("Login");
 }

}
