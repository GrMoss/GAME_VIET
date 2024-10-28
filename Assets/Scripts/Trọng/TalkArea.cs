using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkArea : MonoBehaviour
{
    [SerializeField] private GameObject F_Button;

    private void Awake()
    {
        F_Button.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            F_Button.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            F_Button.SetActive(false);
        }
    }
}
