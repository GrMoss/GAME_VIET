using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLogin : MonoBehaviour
{
 public void ButtonPlay()
 {
     SceneManager.LoadScene("DiCaKheo");
 }

 public void Exit()
 {
     Application.Quit();
 }
}
