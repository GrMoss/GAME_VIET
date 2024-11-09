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
    public float gameTime = 60f;
    private int score = 0;
    private int currentTargetPotIndex;

    private void Start()
    {
        SelectNewTargetPot(); 
        StartCoroutine(Countdown());
    }

    public void SelectNewTargetPot()
    {
 
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
        scoreText.text = "Điểm: " + score.ToString();
    }

    private IEnumerator Countdown()
    {
        while (gameTime > 0)
        {
            yield return new WaitForSeconds(1f);
            gameTime--;

        }
    }
}
