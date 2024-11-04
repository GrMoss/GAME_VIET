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
    if (Player.Instance != null && player[Player.Instance.gender] != null)
    {
        player[Player.Instance.gender].SetActive(true);
    }
    else
    {
        Debug.LogError("Player instance or player gender is null.");
    }
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
        if (Player.Instance != null && player[Player.Instance.gender] != null)
        {
            player[Player.Instance.gender].SetActive(false);
            hasCheckedWinCondition = true; 
        }
        else
        {
            Debug.LogError("Player instance or player gender is null.");
        }
    }
}
}