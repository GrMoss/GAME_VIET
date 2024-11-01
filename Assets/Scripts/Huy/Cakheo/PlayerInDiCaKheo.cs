using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInDiCaKheo : MonoBehaviour
{

    [SerializeField] private GameObject[] player;

    private void Start() {
        player[Player.Instance.gender].SetActive(true);
    }
}
