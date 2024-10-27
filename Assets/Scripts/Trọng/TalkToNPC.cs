using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkToNPC : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    { 
        if (collision.CompareTag("NPC"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                NPC_Behaviour newNPC;
                newNPC = collision.GetComponentInParent<NPC_Behaviour>();
                if (newNPC.isTalking == false) newNPC.Interact();
            }
        }
    }
}
