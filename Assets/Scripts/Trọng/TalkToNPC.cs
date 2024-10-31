using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TalkToNPC : MonoBehaviour
{
    [SerializeField] private GameObject interactButton;
    private NPC_Behaviour newNPC;
    public GameObject dialogPanel;
    public static bool isEndOfDialog;
    PlayerInput input;
    private void Awake()
    {
        input = GetComponent<PlayerInput>();
    }
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
                if (Input.GetKeyDown(KeyCode.F))
                {
                    newNPC.Interact();
                    input.enabled = false;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("NPC")) interactButton.SetActive(false);
    }

    public void TalkWithNPC()
    {
        if (newNPC.isInteractable == true)
        {
            newNPC.Interact();
            input.enabled = false;
        }
    }
    
    public void CloseDialog()
    {
        if (isEndOfDialog == true) 
        {
            input.enabled = true;
            isEndOfDialog = false;
            dialogPanel.SetActive(false);
            interactButton.SetActive(false);
        }
    }
}
