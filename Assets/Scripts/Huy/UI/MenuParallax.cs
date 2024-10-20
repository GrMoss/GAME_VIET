
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuParallax : MonoBehaviour
{
    public float offsetMultiplier = 1f;  // Độ nhạy của chuyển động
    public float smoothTime = 0.3f;      // Thời gian làm mượt
    public float boundaryX = 5f;         // Giới hạn theo trục X
    public float boundaryY = 3f;         // Giới hạn theo trục Y

    private Vector2 startPosition;       // Vị trí ban đầu của đối tượng
    private Vector3 velocity;            // Tốc độ làm mượt

    void Start()
    {
        startPosition = transform.position;  // Lưu lại vị trí ban đầu
    }

    void Update()
    {
        // Lấy giá trị từ cảm biến gia tốc của điện thoại
        Vector2 tilt = new Vector2(Input.acceleration.x, Input.acceleration.y);

        // Giới hạn giá trị tilt trong khoảng [-1, 1]
        tilt.x = Mathf.Clamp(tilt.x, -1f, 1f);
        tilt.y = Mathf.Clamp(tilt.y, -1f, 1f);

        // Tính toán vị trí mới với giới hạn theo boundaryX và boundaryY
        Vector2 targetPosition = new Vector2(
            Mathf.Clamp(startPosition.x + (tilt.x * offsetMultiplier), startPosition.x - boundaryX, startPosition.x + boundaryX),
            Mathf.Clamp(startPosition.y + (tilt.y * offsetMultiplier), startPosition.y - boundaryY, startPosition.y + boundaryY)
        );

        // Di chuyển đối tượng tới vị trí mới với hiệu ứng mượt
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}