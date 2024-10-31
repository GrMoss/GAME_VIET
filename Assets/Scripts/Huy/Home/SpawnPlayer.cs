using UnityEngine;
using Cinemachine;

public class Spawn_Player : MonoBehaviour
{
    public GameObject[] playerPrefabs; 
    public CinemachineVirtualCamera virtualCamera;

    private void UpdateVirtualCameraTarget(Transform playerTransform)
    {
        if (virtualCamera != null)
        {
            virtualCamera.Follow = playerTransform;
            virtualCamera.LookAt = playerTransform;
        }
    }

    private void Start()
    {
        int characterIndex = Player.Instance.gender;

        // Kiểm tra chỉ số có hợp lệ không
        if (characterIndex >= 0 && characterIndex < playerPrefabs.Length)
        {
            Vector3 positionPlayer = new Vector3(Player.Instance.positionPlayer[0],Player.Instance.positionPlayer[1],Player.Instance.positionPlayer[2]);

            // Spawn Player
            GameObject player = Instantiate(playerPrefabs[characterIndex], positionPlayer, Quaternion.identity);

            // Gọi hàm để cập nhật mục tiêu của Virtual Camera
            UpdateVirtualCameraTarget(player.transform);

            // Lấy giới tính từ nhân vật vừa spawn
            Player playerComponent = player.GetComponent<Player>();
            if (playerComponent != null)
            {
                int gender = playerComponent.gender;
            }
        }
        else
        {
            Debug.LogError("Chỉ số nhân vật không hợp lệ: " + characterIndex);
        }
    }
}