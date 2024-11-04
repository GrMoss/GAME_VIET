using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameComplete : MonoBehaviour
{
    [HideInInspector] public bool isSuccess;
    public GameObject homeButton;
    public GameObject replayButton;
    public GameObject prizeButton;
    public TextMeshProUGUI resultText;
    CardData cardData;
    List<ItemData> itemData = new List<ItemData>();
    Player player;
    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        cardData = FindObjectOfType<CardData>();
        itemData = cardData.itemData;
    }

    private void OnEnable()
    {
        if (isSuccess)
        {
            prizeButton.SetActive(true);
            resultText.text = "HOÀN THÀNH";
            if (!player.IsLevelCompleted(69))
            {
                player.MarkLevelAsCompleted(69);
                player.AddOrUpdateItemById(13, 1);
            }
            else ClosePrize();
            for (int i = 0; i < 6; i++)
            {
                player.AddOrUpdateItemById(i, itemData[i].wantedAmount);
                Debug.Log(itemData[i].wantedAmount);
            }
        }
        else
        {
            replayButton.SetActive(true);
            homeButton.SetActive(true);
            resultText.text = "THẤT BẠI";
        }
    }

    public void ClosePrize()
    {
        prizeButton.SetActive(false);
        replayButton.SetActive(true);
        homeButton.SetActive(true);
    }
}
