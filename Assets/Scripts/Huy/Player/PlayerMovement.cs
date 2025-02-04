using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovememt : MonoBehaviour
{
    [SerializeField] private InputActionReference moveActionToUse;

    [SerializeField] private float speed = 5f;

    private Rigidbody2D myRigidbody2D;
    private Vector2 moveDirection;
    private Animator animator;

    private Vector2 lastMoveDirection;
    
    // private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        moveActionToUse.action.Enable();
    }

    private void OnDisable()
    {
        moveActionToUse.action.Disable();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = moveDirection * speed;
        SendPositionPlayer();
    }

    private void SendPositionPlayer()
    {
        Player.Instance.positionPlayer[0] = transform.position.x;
        Player.Instance.positionPlayer[1] = transform.position.y;
        Player.Instance.positionPlayer[2] = transform.position.z;
    }
    
    private void Move()
    {
        moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        if (moveDirection.x != 0 || moveDirection.y != 0)
        {
            lastMoveDirection = moveDirection;
        }
        Anim();
    }

    private void Anim()
    {
        animator.SetFloat("X",moveDirection.x);
        animator.SetFloat("Y",moveDirection.y);
        animator.SetFloat("LastX",lastMoveDirection.x);
        animator.SetFloat("LastY",lastMoveDirection.y);
        animator.SetFloat("AnimMoveMagnitude",moveDirection.magnitude);
        
    }
    

}