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
    // private Animator animator;
    // private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        // animator = GetComponent<Animator>();
        // spriteRenderer = GetComponent<SpriteRenderer>();
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
        moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        
        // // Cập nhật trạng thái hoạt hình nếu có
        // if (animator != null)
        // {
        //     animator.SetBool("Walk", moveDirection.magnitude > 0);
        // }
        //
        // // Lật hình nhân vật dựa trên hướng di chuyển
        // if (moveDirection.x != 0)
        // {
        //     spriteRenderer.flipX = moveDirection.x < 0;
        // }
    }

    private void FixedUpdate()
    {
        // Di chuyển nhân vật dựa trên hướng và tốc độ
        myRigidbody2D.velocity = moveDirection * speed;
    }
}