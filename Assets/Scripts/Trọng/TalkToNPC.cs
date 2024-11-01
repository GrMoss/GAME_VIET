using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TalkToNPC : MonoBehaviour
{
    private GameObject interactButton;
    private NPC_Behaviour newNPC;
    private GameObject dialogPanel;
    public static bool isEndOfDialog;
    Button interact;
    Button dialog;
    PlayerInput input;
    private void Awake()
    {
        //input = GetComponent<PlayerInput>();
        interactButton = GameObject.Find("InteractButton");
        dialogPanel = GameObject.Find("Dialog Panel");
        newNPC = GetComponent<NPC_Behaviour>();
        interact = GameObject.FindWithTag("Interact").GetComponent<Button>();
        dialog = GameObject.FindWithTag("Dialog").GetComponent<Button>();
    }
    private void Start()
    {
        interactButton.SetActive(false);
        dialogPanel.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.CompareTag("Player"))
        {
            //newNPC = collision.GetComponentInParent<NPC_Behaviour>();
            input = collision.GetComponent<PlayerInput>();
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Invoke("NewMethod", 0.2f);
        }
    }

    private void NewMethod()
    {
        interact.onClick.AddListener(TalkWithNPC);
        dialog.onClick.AddListener(TalkWithNPC);
        dialog.onClick.AddListener(CloseDialog);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) interactButton.SetActive(false);
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
            interact.onClick.RemoveAllListeners();
            dialog.onClick.RemoveAllListeners();
            dialogPanel.SetActive(false);
            interactButton.SetActive(false);
        }
    }
}
