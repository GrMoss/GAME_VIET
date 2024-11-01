using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInDiCaKheo : MonoBehaviour
{

    [SerializeField] private GameObject[] player;
    [SerializeField] PiontDiCaKheo piontDiCaKheo;

    private void Start() {
        player[Player.Instance.gender].SetActive(true);
    }

        private void FixedUpdate() 
    {
        if(PiontDiCaKheo.Point >= piontDiCaKheo.piontWinGame)
        {
            player[Player.Instance.gender].SetActive(false);
        }
    }
}
