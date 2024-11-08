using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpOnButton : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    private Animator animator;
    private Collider2D myCollider;

    [SerializeField] private float jumpForce;
    [SerializeField] private float fastFallSpeed = -20f; // Tốc độ rơi nhanh khi nhấn nút xuống
    [SerializeField] private bool isJump;
    [SerializeField] private InputActionReference jumpAction; // Tham chiếu đến hành động nhảy từ Input Actions
    [SerializeField] private InputActionReference downAction; // Tham chiếu đến hành động xuống từ Input Actions

    private void Awake()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        myCollider = GetComponent<Collider2D>();

     
        jumpAction.action.performed += OnJump;
        downAction.action.performed += OnFastFall;
    }

    private void OnEnable()
    {
        if (jumpAction != null && jumpAction.action != null)
            jumpAction.action.Enable();

        if (downAction != null && downAction.action != null)
            downAction.action.Enable();
    }

    private void OnDisable()
    {
        if (jumpAction != null && jumpAction.action != null)
            jumpAction.action.Disable();

        if (downAction != null && downAction.action != null)
            downAction.action.Disable();
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        if (!isJump)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, jumpForce);
            isJump = true;
            myCollider.enabled = false;
        }
    }

    private void OnFastFall(InputAction.CallbackContext context)
    {
        // Chỉ kích hoạt rơi nhanh khi đang trên không
        if (isJump && myRigidbody2D.velocity.y > fastFallSpeed)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, fastFallSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isJump) return;
        if (collision.CompareTag("Ground"))
        {
            myCollider.enabled = true;
        }
    }
}
