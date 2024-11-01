using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] private GameObject[] avatar;
    public TMP_Text textName;

    private void Start() {
        textName.text = Player.Instance.playerName;
        avatar[Player.Instance.gender].SetActive(true);
        
    }



}
