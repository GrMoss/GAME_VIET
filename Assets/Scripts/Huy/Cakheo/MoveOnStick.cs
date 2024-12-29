using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveOnStick : MonoBehaviour
{
    [SerializeField] private InputActionReference moveActionToUse;

    [SerializeField] private float speed = 5f;

    private Rigidbody2D myRigidbody2D;
    private Vector2 moveDirection;
    private Animator animator;
    
    // private Vector2 lastMoveDirection;
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
        myRigidbody2D.linearVelocity = moveDirection * speed;
    }
    
    private void Move()
    {
        Anim();
        moveDirection = moveActionToUse.action.ReadValue<Vector2>();
    }

    private void Anim()
    {
        // animator.SetFloat("X",moveDirection.x);
        // animator.SetFloat("Y",moveDirection.y);
        // animator.SetFloat("LastX",lastMoveDirection.x);
        // animator.SetFloat("LastY",lastMoveDirection.y);
        // animator.SetFloat("AnimMoveMagnitude",moveDirection.magnitude);
        
    }
    

}