using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Behaviour : MonoBehaviour
{
    public List<NPC_Checkpoints> NPC_Checkpoints;

    [SerializeField] private float speed;
    private int targetIndex = 0;
    private bool isMoving = true;
    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        if(isMoving) MoveToNextCheckpoint();
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
