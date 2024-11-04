using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UI;

public class CardData : MonoBehaviour
{
    public List<ItemData> itemData = new List<ItemData>();
    public List<TextMeshProUGUI> itemCountText = new List<TextMeshProUGUI>();
    int[] itemCount = new int[6];
    public int multiPickAmount;
    private string firstPick, secondPick;
    [HideInInspector] public int pickIndex;
    [HideInInspector] public bool correctPick;
    [HideInInspector] public bool onePair;
    [HideInInspector] public CardBehaviour[] cardBehaviours = new CardBehaviour[2];
    public Clock clock;
    public GameComplete gameComplete;
    public GameObject resultPanel;
    public List<GameObject> cards;

    private void Start()
    {
        UpdateItemCount();
    }
    private void Update()
    {
        if (cardBehaviours[0] != null && cardBehaviours[1] != null)
        {
            cardBehaviours[0].StartTrigger(correctPick);
            cardBehaviours[1].StartTrigger(correctPick);
            cardBehaviours[0] = null;
            cardBehaviours[1] = null;
            correctPick = false;
        }
    }

    private void UpdateItemCount()
    {
        for (int i = 0; i < 6; i++)
        {
            if (itemCount[i] >= itemData[i].wantedAmount)
            {
                itemCountText[i].color = Color.green;
            }
            if (itemCount[i] > itemData[i].wantedAmount)
            {
                itemCount[i] = itemData[i].wantedAmount;
                clock.timer += 3;
            }
            itemCountText[i].text = ": " + itemCount[i] + " / " + itemData[i].wantedAmount;
        }
    }

    public void CountCorrectItem(string itemName, int itemIndex)
    {
        if (pickIndex == 0) firstPick = itemName;
        else
        {
            onePair = true;
            secondPick = itemName;
            if (firstPick == secondPick)
            {
                itemCount[itemIndex]++;
                correctPick = true;
                UpdateItemCount();
                CheckComplete();
            }
        }
        pickIndex++;
        if (pickIndex > 1)
        {
            pickIndex = 0;
            firstPick = null;
            secondPick = null;
        }
    }
    public void CheckComplete()
    {
        int checker = 0;
        for (int i = 0; i < 6; i++)
        {
            if (itemCount[i] >= itemData[i].wantedAmount) checker++;
        }
        if (checker == 6)
        {
            StopGame();
            gameComplete.isSuccess = true;
            clock.isGameRunning = false;
        }
    }
    public void StopGame()
    {
        foreach (var card in cards)
        {
            Button button = card.GetComponent<Button>();
            button.interactable = false;
        }
        Invoke("ShowResult", 2f);
    }

    private void ShowResult()
    {
        resultPanel.SetActive(true);
    }
}

[System.Serializable]
public class ItemData
{
    public Sprite itemSprite;
    public string itemName;
    public int wantedAmount;
}
