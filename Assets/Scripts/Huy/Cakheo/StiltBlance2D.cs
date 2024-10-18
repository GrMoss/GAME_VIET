using System.Collections;
using UnityEngine;

public class StiltBalance2D : MonoBehaviour
{
    public Transform player;             // Nhân vật 2D
    public Rigidbody2D playerRb;         // Rigidbody của nhân vật
    public float maxTiltAngle = 30f;     // Góc nghiêng tối đa trước khi ngã
    public float tiltSensitivity = 2f;   // Độ nhạy của thăng bằng
    public float moveSpeed = 2f;         // Tốc độ di chuyển của nhân vật
    public float windForce = 5f;         // Lực gió
    public Vector2 windDirection;        // Hướng gió
    public bool isVibrating = false;     // Kiểm tra trạng thái rung

    private Vector3 initialRotation;     // Trạng thái xoay ban đầu

    void Start()
    {
        Input.gyro.enabled = true;       // Bật con quay hồi chuyển
        initialRotation = player.eulerAngles; // Lưu lại trạng thái ban đầu
        windDirection = new Vector2(Random.Range(-1f, 1f), 0).normalized; // Hướng gió ngẫu nhiên
    }

    void Update()
    {
        HandleBalanceAndMovement();      // Xử lý di chuyển và thăng bằng
        HandleWind();                    // Xử lý lực gió
    }

    void HandleBalanceAndMovement()
    {
        // Lấy thông tin từ con quay hồi chuyển
        Vector3 gyroRotation = Input.gyro.rotationRateUnbiased;
        float tiltZ = gyroRotation.z * tiltSensitivity;

        // Cập nhật góc nghiêng của nhân vật
        player.eulerAngles = new Vector3(initialRotation.x, initialRotation.y, initialRotation.z - tiltZ);

        // Di chuyển nhân vật theo hướng nghiêng
        playerRb.velocity = new Vector2(gyroRotation.x * moveSpeed, playerRb.velocity.y);

        // Kiểm tra nếu góc nghiêng gần vượt ngưỡng và tạo nhịp rung
        float currentTilt = Mathf.Abs(player.eulerAngles.z);
        if (currentTilt > maxTiltAngle * 0.75f && !isVibrating)
        {
            StartCoroutine(VibratePattern()); // Bắt đầu rung khi gần ngã
        }

        // Nếu góc nghiêng vượt ngưỡng tối đa
        if (currentTilt > maxTiltAngle)
        {
            Debug.Log("Bạn đã ngã!");
            StopCoroutine(VibratePattern()); // Ngừng rung khi ngã
            // Reset game hoặc xử lý khi ngã
        }
    }

    void HandleWind()
    {
        // Tạo sự thay đổi nhẹ trong hướng gió và tốc độ gió
        windDirection += new Vector2(Random.Range(-0.01f, 0.01f), 0).normalized;
        windForce = Mathf.Clamp(windForce + Random.Range(-0.1f, 0.1f), 0f, 10f); // Giới hạn tốc độ gió

        // Áp dụng lực gió lên nhân vật
        Vector2 windForceVector = new Vector2(windDirection.x, 0) * windForce;
        playerRb.AddForce(windForceVector, ForceMode2D.Force);
    }

    IEnumerator VibratePattern()
    {
        isVibrating = true;
        while (true)
        {
            Handheld.Vibrate();  // Rung thiết bị
            yield return new WaitForSeconds(0.2f); // Rung trong 0.2 giây
            yield return new WaitForSeconds(0.3f); // Nghỉ 0.3 giây
        }
    }
}