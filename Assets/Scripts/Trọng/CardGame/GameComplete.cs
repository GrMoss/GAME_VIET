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

    private void OnEnable()
    {
        if (isSuccess)
        {
            prizeButton.SetActive(true);
            resultText.text = "HOÀN THÀNH";
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
