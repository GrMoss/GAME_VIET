using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInDiCaKheo : MonoBehaviour
{
    [SerializeField] private GameObject[] player;
    [SerializeField] PointDiCaKheo pointDiCaKheo;
    
    private bool hasCheckedWinCondition = false;

    private void Start() 
    {
        player[Player.Instance.gender].SetActive(true);
        hasCheckedWinCondition = false; 
    }

    private void FixedUpdate() 
    {
        if (!hasCheckedWinCondition) 
        {
            SetATPlayer();
        }
    }

    private void SetATPlayer()
    {
        if (PointDiCaKheo.Point >= pointDiCaKheo.pointWinGame)
        {
            player[Player.Instance.gender].SetActive(false);
            hasCheckedWinCondition = true; 
        }
    }
}