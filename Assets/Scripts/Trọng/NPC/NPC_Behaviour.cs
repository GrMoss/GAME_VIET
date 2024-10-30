using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NPC_Behaviour : MonoBehaviour
{
    public List<NPC_Checkpoints> NPC_Checkpoints;

    [SerializeField] private float speed;
    [SerializeField] private bool canTalk;
    private int targetIndex = 0;
    private bool isMoving = true;
    private Animator animator;

    [SerializeField] private DialogData myDialogs;
    List<string> dialogs = new List<string>();
    private int dialogIndex;
    [HideInInspector] public bool isTalkable = true;
    [HideInInspector] public bool isInteractable;
    [SerializeField] private GameObject interactableSymbol;

    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI NPC_Name;
    public Image NPC_Sprite;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        if (canTalk) isInteractable = true;
        if (myDialogs != null)
            foreach (string dialog in myDialogs.dialogs)
            {
                dialogs.Add(dialog);
            }
    }

    private void FixedUpdate()
    {
        if (!canTalk) if (isMoving) MoveToNextCheckpoint();
    }

    public void Interact()
    {
        NPC_Name.text = myDialogs.myName;
        NPC_Sprite.sprite = myDialogs.mySprite;
        NextDialog();
    }

    private void NextDialog()
    {
        if (dialogIndex < dialogs.Count) 
        {
            dialogText.text = dialogs[dialogIndex];
        }
        isInteractable = false;
        dialogIndex++;
        Invoke("StopDialog", 1f);
    }
    private void StopDialog()
    {
        isInteractable = true;
        if (dialogIndex == dialogs.Count) EndDialog();
    }

    private void EndDialog()
    {
        dialogIndex = 0;
        interactableSymbol.SetActive(false);
        TalkToNPC.isEndOfDialog = true;
        isInteractable = false;
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
        Vector2 moveDirection = (targetPosition - transform.position).normalized;
        Anim(moveDirection);
    }
    private void Anim(Vector2 moveDirection)
    {
        animator.SetFloat("X", moveDirection.x);
        animator.SetFloat("Y", moveDirection.y);
        animator.SetFloat("AnimMoveMagnitude", moveDirection.magnitude);

    }
}

[System.Serializable]
public class NPC_Checkpoints
{
    public Transform checkpoints;
    public float checkTimer;
}
