using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    CardData cardData;
    public Sprite[] cardSprite = new Sprite[2];
    public GameObject itemObject;
    public Image itemImage;

    private Image cardImage;
    private int cardIndex;
    private bool isItemActive;
    private Button pickButton;
    private int itemIndex;
    Animator ani;
    private void Awake()
    {
        cardData = GetComponentInParent<CardData>();
        cardImage = GetComponent<Image>();
        pickButton = GetComponent<Button>();
        ani = GetComponent<Animator>();
    }
    private void Start()
    {
        ChoseAnItem();
    }
    public void ChoseAnItem()
    {
        itemIndex = Random.Range(0, cardData.itemData.Count);
        itemImage.sprite = cardData.itemData[itemIndex].itemSprite;
    }
    public void TriggerFlipAnimation()
    {
        ani.SetTrigger("Flip");
    }
    public void FlipCardUp()
    {
        QuickSpriteChange();
        cardData.cardBehaviours[cardData.pickIndex] = this;
        cardData.CountCorrectItem(cardData.itemData[itemIndex].itemName, itemIndex);
    }
    public void StartTrigger(bool isCorrect)
    {
        StartCoroutine(TriggerAnswer(isCorrect));
    }
    IEnumerator TriggerAnswer(bool isCorrect)
    {
        yield return new WaitForSeconds(1f);
        if (isCorrect)
        {
            ani.SetTrigger("Correct");
            yield return new WaitForSeconds(1f);
            ChoseAnItem();
            cardData.correctPick = false;
        }
        else ani.SetTrigger("Wrong");
    }
    public void FlipCardDown()
    {
        QuickSpriteChange();
    }

    private void QuickSpriteChange()
    {
        cardIndex++;
        if (cardIndex > 1) cardIndex = 0;
        cardImage.sprite = cardSprite[cardIndex];
        isItemActive = !isItemActive;
        itemObject.SetActive(isItemActive);
        pickButton.interactable = !isItemActive;
    }
}
