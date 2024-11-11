using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScenes : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject CheckPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            PositionPlayer();
        }
    }

    private void PositionPlayer()
    {
        Player.Instance.positionPlayer[0] = CheckPoint.transform.position.x;
        Player.Instance.positionPlayer[1] = CheckPoint.transform.position.y;
        Player.Instance.positionPlayer[2] = CheckPoint.transform.position.z;
    }
}
