using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardData : MonoBehaviour
{
    public List<ItemData> itemData = new List<ItemData>();
    public List<TextMeshProUGUI> itemCountText = new List<TextMeshProUGUI>();
    int[] itemCount = new int[6];
    private string firstPick, secondPick;
    [HideInInspector] public int pickIndex;
    [HideInInspector] public bool correctPick;
    [HideInInspector] public bool onePair;
    [HideInInspector] public CardBehaviour[] cardBehaviours = new CardBehaviour[2];
    private void Start()
    {
        UpdateItemCount();
    }
    private void Update()
    {
        if (cardBehaviours[0] != null && cardBehaviours[1] != null)
        {
            Debug.Log("OK");
            cardBehaviours[0].StartTrigger(correctPick);
            cardBehaviours[1].StartTrigger(correctPick);
            cardBehaviours[0] = null;
            cardBehaviours[1] = null;
        }
    }

    private void UpdateItemCount()
    {
        for (int i = 0; i < 6; i++)
        {
            if (itemCount[i] > itemData[i].wantedAmount) itemCount[i] = itemData[i].wantedAmount;
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
                Debug.Log("Correct");
            }
            else Debug.Log("Wrong");
        }
        pickIndex++;
        if (pickIndex > 1)
        {
            pickIndex = 0;
            firstPick = null;
            secondPick = null;
        }
    }
}

[System.Serializable]
public class ItemData
{
    public Sprite itemSprite;
    public string itemName;
    public int wantedAmount;
}
