using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;   
    private Vector2 moveInput;     
    private Rigidbody2D rb;       
    private Vector2 currentVelocity; 

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }
    
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>(); 
    }
   
    private void FixedUpdate()
    {
        // Tính toán vận tốc mục tiêu từ đầu vào người chơi
        Vector2 targetVelocity = moveInput.normalized * moveSpeed;

        // Sử dụng Vector2.Lerp để nội suy từ vận tốc hiện tại tới vận tốc mục tiêu để có sự chuyển động mượt mà
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.fixedDeltaTime * 10f);
    }
}