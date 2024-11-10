using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class GamePlayDapNieu : MonoBehaviour
{
    public Nieu[] pots; 
    public Image targetPotImage;
    public Sprite[] potSprites; 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public float gameTime = 60f;
    private int score = 0;
    private int currentTargetPotIndex;
    [SerializeField] private bool isTimed;
    private void Start()
    {
        SelectNewTargetPot(); 
        StartCoroutine(Countdown());
    }

    public void SelectNewTargetPot()
    {
        if (DapNieuPoint.hasWon == true) return;
        foreach (var pot in pots)
        {
            pot.hasItem = false;
        }

   
        currentTargetPotIndex = Random.Range(0, pots.Length);
        pots[currentTargetPotIndex].hasItem = true;


        targetPotImage.sprite = potSprites[currentTargetPotIndex];
    }

    public void PotClicked(int potIndex)
    {
        if (potIndex == currentTargetPotIndex)
        {
            AddScore(1);         
            SelectNewTargetPot(); 
        }
    }

    public void AddScore(int points)
    {
        score += points;
        DapNieuPoint.Point = score;
        scoreText.text = score.ToString();
    }

    private IEnumerator Countdown()
    {
        while (gameTime > 0)
        {
            if (DapNieuPoint.hasWon == true) yield break;
            yield return new WaitForSeconds(1f);
            gameTime--;
            int minutes = Mathf.FloorToInt(gameTime / 60);
            int seconds = Mathf.FloorToInt(gameTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if(gameTime <= 10)
                timeText.color = Color.red;
            if (gameTime <= 0)
                isTimed = true;
        }
    }
}
