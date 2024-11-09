using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform playerTransform;
    private void Start()
    {
        // Cập nhật Virtual Camera theo Player được kích hoạt
        UpdateVirtualCameraTarget(playerTransform);
    }
    private void UpdateVirtualCameraTarget(Transform playerTransform)
    {
        if (virtualCamera != null)
        {
            virtualCamera.Follow = playerTransform;
            virtualCamera.LookAt = playerTransform;
        }
    }
}
