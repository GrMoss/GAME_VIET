// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class Spaceship : MonoBehaviour {
//
// 	Rigidbody2D rb;
// 	float dirX;
// 	float moveSpeed = 20f;
//
// 	// Use this for initialization
// 	void Start () {
// 		rb = GetComponent<Rigidbody2D> ();
// 	}
// 	
// 	// Update is called once per frame
// 	void Update () {
// 		dirX = Input.acceleration.x * moveSpeed;
// 		transform.position = new Vector2 (Mathf.Clamp (transform.position.x, -7.5f, 7.5f), transform.position.y);
// 	}
//
// 	void FixedUpdate()
// 	{
// 		rb.velocity = new Vector2 (dirX, 0f);
// 	}
//
// }
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

        // Di chuyển tàu vũ trụ
        rb.MovePosition(newPosition);
    }
}