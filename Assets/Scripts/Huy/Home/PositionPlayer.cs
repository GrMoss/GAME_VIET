using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlayer : MonoBehaviour
{
    private void Start() 
    {   
        transform.position = positionPlayer;
    }
   private Vector3 positionPlayer = new Vector3(
        Player.Instance.positionPlayer[0],
        Player.Instance.positionPlayer[1],
        Player.Instance.positionPlayer[2]);
}
