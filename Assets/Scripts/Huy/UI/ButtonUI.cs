using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonUI : MonoBehaviour
{

   public void ExtToHome()
   {
      SceneManager.LoadScene("Home");
   }

   public void StartNewGame()
   {
      SceneManager.LoadScene("Home");
      TimelineManager.Instance.SetActiveTimelineStart(true);
   }

   public void Exit()
   {
      Application.Quit();
   }

   public void ExitToMenu()
   {
      SceneManager.LoadScene("Login");
      Player.Instance.ResetPlayerData();
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

   public void MiniGameTimLeVat()
   {
      SceneManager.LoadScene("TimLeVat");
   }

   public void MiniGameNhayBaoBo()
   {
      SceneManager.LoadScene("NhayBaoBo");
   }

    public void MiniGameDapNieu()
   {
      SceneManager.LoadScene("DapNieu");
   }

}

