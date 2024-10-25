
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    Rigidbody2D rb;
    float dirX;
    [SerializeField] float moveSpeed = 20f;  // Tốc độ di chuyển
    [SerializeField] float boundaryX = 7.5f; // Giới hạn di chuyển trục X

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Lấy giá trị từ cảm biến gia tốc
        dirX = Input.acceleration.x * moveSpeed;
    }

    void FixedUpdate()
    {
        // Tính toán vị trí mới, đảm bảo không vượt quá giới hạn
        Vector2 newPosition = rb.position + new Vector2(dirX * Time.fixedDeltaTime, 0f);
        newPosition.x = Mathf.Clamp(newPosition.x, -boundaryX, boundaryX); // Giới hạn theo trục X
        
        rb.MovePosition(newPosition);
    }
}