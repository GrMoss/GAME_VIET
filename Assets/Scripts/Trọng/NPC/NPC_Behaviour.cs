using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behaviour : MonoBehaviour
{
    public List<NPC_Checkpoints> NPC_Checkpoints;

    [SerializeField] private float speed;
    [SerializeField] private bool isNotOldMan;
    private int targetIndex = 0;
    private bool isMoving = true;

    [SerializeField] private DialogData myDialogs;
    List<string> dialogs = new List<string>();
    private int dialogIndex;
    [HideInInspector] public bool isTalking;
    private void Start()
    {
        foreach (string dialog in myDialogs.dialogs)
        {
            dialogs.Add(dialog);
        }
    }

    private void FixedUpdate()
    {
        if (isNotOldMan) if (isMoving) MoveToNextCheckpoint();
    }

    public void Interact()
    {
        isTalking = true;
        NextDialog();
    }

    private void NextDialog()
    {
        if (dialogIndex < dialogs.Count) 
        {
            Debug.Log(dialogs[dialogIndex]);
        }
        dialogIndex++;
        Invoke("StopDialog", 2f);
        if (dialogIndex == dialogs.Count) EndDialog();
    }
    public void StopDialog()
    {
        isTalking = false;
    }

    private void EndDialog()
    {
        Debug.Log("End of Dialog here");
        dialogIndex = 0;
    }

    void StayAtPlace()
    {
        isMoving = false;
        Invoke("StartMoving", NPC_Checkpoints[targetIndex].checkTimer);
    }

    void StartMoving()
    {
        isMoving = true;
        NextTarget();
    }

    void NextTarget()
    {
        targetIndex++;
        if (targetIndex > NPC_Checkpoints.Count - 1) targetIndex = 0;
    }

    void MoveToNextCheckpoint()
    {
        Vector3 targetPosition = NPC_Checkpoints[targetIndex].checkpoints.position;
        Vector3 moveInput = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.position = moveInput;
        if (transform.position == targetPosition) StayAtPlace();
    }
}

[System.Serializable]
public class NPC_Checkpoints
{
    public Transform checkpoints;
    public float checkTimer;
}
