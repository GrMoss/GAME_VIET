using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPlayer : MonoBehaviour
{
    private Vector3 positionPlayer = new Vector3(
       Player.Instance.positionPlayer[0],
       Player.Instance.positionPlayer[1],
       Player.Instance.positionPlayer[2]);

    private void Start()
    {
        transform.position = positionPlayer;
    }

    private void FixedUpdate()
    {
        SendPositionPlayer();
    }

    private void SendPositionPlayer()
    {
        Player.Instance.positionPlayer[0] = transform.position.x;
        Player.Instance.positionPlayer[1] = transform.position.y;
        Player.Instance.positionPlayer[2] = transform.position.z;
    }
}
