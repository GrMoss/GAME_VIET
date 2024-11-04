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
    AudioManager audioManager;
    private bool clickable = true;
    private void Awake()
    {
        cardData = GetComponentInParent<CardData>();
        cardImage = GetComponent<Image>();
        pickButton = GetComponent<Button>();
        ani = GetComponent<Animator>();
        audioManager = FindObjectOfType<AudioManager>();
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
        if (clickable && cardData.multiPickAmount < 5)
        {
            ani.SetTrigger("Flip");
            clickable = false;
            cardData.multiPickAmount++;
        }
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
        yield return new WaitForSeconds(.5f);
        if (isCorrect)
        {
            ani.SetTrigger("Correct");
            yield return new WaitForSeconds(1f);
            ChoseAnItem();
            audioManager.Play("Yes");
        }
        else
        {
            ani.SetTrigger("Wrong");
            audioManager.Play("No");
        }
    }
    public void FlipCardDown()
    {
        QuickSpriteChange();
        cardData.multiPickAmount--;
    }

    private void QuickSpriteChange()
    {
        cardIndex++;
        if (cardIndex > 1) cardIndex = 0;
        cardImage.sprite = cardSprite[cardIndex];
        isItemActive = !isItemActive;
        itemObject.SetActive(isItemActive);
        Invoke("Clickable", .5f);
    }
    public void Clickable()
    {
        clickable = true;
        pickButton.interactable = !isItemActive;
    }
}
