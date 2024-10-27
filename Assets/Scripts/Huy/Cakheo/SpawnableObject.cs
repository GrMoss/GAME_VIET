using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnableObject : MonoBehaviour
{
    private SpawnBox objectPool;
    private float speed;
    private Vector2 direction;
   

    public void SetPool(SpawnBox pool)
    {
        objectPool = pool;
    }

    public void SetSpeedAndDirection(Vector2 dir, float spd)
    {
        direction = dir.normalized; // Chỉ giữ hướng
        speed = spd; // Đặt tốc độ
    }

    void Update()
    {
        // Di chuyển theo hướng và tốc độ đã chỉ định
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
           // Kiểm tra xem đối tượng va chạm có phải là người chơi không
        if (other.collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);


        }
    }
}