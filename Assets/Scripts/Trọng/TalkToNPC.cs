using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToNPC : MonoBehaviour
{
    [SerializeField] private GameObject interactButton;
    private NPC_Behaviour newNPC;
    private void Start()
    {
        interactButton.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.CompareTag("NPC"))
        {
            newNPC = collision.GetComponentInParent<NPC_Behaviour>();
            if (newNPC.isInteractable == true)
            {
                interactButton.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F)) newNPC.Interact();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC")) interactButton.SetActive(false);
    }
    public void TalkWithNPC()
    {
        if (newNPC.isInteractable == true) newNPC.Interact();
    }
}
