using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cay : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveDistance = 3f;
    public float flySpeed = 5f;
    public float flyTime = 1f;
    public float posTarget;
    public bool useTiltControl = false; // Biến để bật/tắt điều khiển nghiêng
    private Vector3 startPosition;
    private bool isFlying = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (DapNieuPoint.hasWon == true) return;

        if (!isFlying)
        {
            if (useTiltControl)
            {
                // Sử dụng góc nghiêng của thiết bị để điều khiển vị trí
                float tilt = Input.acceleration.x; // Giá trị từ -1 đến 1, 0 là ngang
                transform.position = new Vector3(
                    startPosition.x + tilt * moveDistance / 2,
                    startPosition.y,
                    startPosition.z
                );
            }
            else
            {
                // Chế độ di chuyển tự động qua lại
                float x = Mathf.PingPong(Time.time * moveSpeed, moveDistance) - moveDistance / 2;
                transform.position = new Vector3(startPosition.x + x, startPosition.y, startPosition.z);
            }
        }
    }

    public void OnButtonPress()
    {
        if (DapNieuPoint.hasWon == true) return;
        if (!isFlying)
            StartCoroutine(FlyAndReturn());
    }

    private IEnumerator FlyAndReturn()
    {
        isFlying = true;
        Vector3 targetPosition = new Vector3(transform.position.x, startPosition.y + posTarget, transform.position.z);
        float distanceToTravel = Vector3.Distance(transform.position, targetPosition);
        float elapsedTime = 0f;

        // Bay đến vị trí đích
        while (elapsedTime < flyTime)
        {
            float progress = (elapsedTime * flySpeed) / distanceToTravel;
            transform.position = Vector3.Lerp(transform.position, targetPosition, progress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        elapsedTime = 0f;

        // Quay về vị trí ban đầu
        while (elapsedTime < flyTime)
        {
            float progress = (elapsedTime * flySpeed) / distanceToTravel;
            transform.position = Vector3.Lerp(transform.position, startPosition, progress);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isFlying = false;
    }
}
