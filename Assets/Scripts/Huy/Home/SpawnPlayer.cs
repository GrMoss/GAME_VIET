// using UnityEngine;
// using Cinemachine;

// public class Spawn_Player : MonoBehaviour
// {
//     public GameObject[] playerPrefabs; 
//     public CinemachineVirtualCamera virtualCamera;

//     private void UpdateVirtualCameraTarget(Transform playerTransform)
//     {
//         if (virtualCamera != null)
//         {
//             virtualCamera.Follow = playerTransform;
//             virtualCamera.LookAt = playerTransform;
//         }
//     }

//     private void Start()
//     {
//         int characterIndex = Player.Instance.gender;

//         // Kiểm tra chỉ số có hợp lệ không
//         if (characterIndex >= 0 && characterIndex < playerPrefabs.Length)
//         {
//             Vector3 positionPlayer = new Vector3(Player.Instance.positionPlayer[0],Player.Instance.positionPlayer[1],Player.Instance.positionPlayer[2]);

//             // Spawn Player
//             GameObject player = Instantiate(playerPrefabs[characterIndex], positionPlayer, Quaternion.identity);

//             // Gọi hàm để cập nhật mục tiêu của Virtual Camera
//             UpdateVirtualCameraTarget(player.transform);

//             // Lấy giới tính từ nhân vật vừa spawn
//             Player playerComponent = player.GetComponent<Player>();
//             if (playerComponent != null)
//             {
//                 int gender = playerComponent.gender;
//             }
//         }
//         else
//         {
//             Debug.LogError("Chỉ số nhân vật không hợp lệ: " + characterIndex);
//         }
//     }
// }
using UnityEngine;
using Cinemachine;

public class Spawn_Player : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Mảng chứa các đối tượng Player cho từng giới tính
    public CinemachineVirtualCamera virtualCamera;
    int characterIndex = Player.Instance.gender;

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
        SelectPlayer();
    }

    private void FixedUpdate() {
        Debug.Log("Vị trí nhân vật: " + playerPrefabs[characterIndex].transform.position);
    }

    public void SelectPlayer()
    {
        // Kiểm tra nếu chỉ số hợp lệ và có Player đã được thiết lập
        if (characterIndex >= 0 && characterIndex < playerPrefabs.Length)
        {
            // Đảm bảo tất cả các đối tượng Player khác đều bị tắt
            foreach (GameObject player in playerPrefabs)
            {
                player.SetActive(false);
            }
            playerPrefabs[characterIndex].transform.position = new Vector3(Player.Instance.positionPlayer[0],Player.Instance.positionPlayer[1],Player.Instance.positionPlayer[2]);
            // Kích hoạt Player theo giới tính
            playerPrefabs[characterIndex].SetActive(true);

            // Cập nhật Virtual Camera theo Player được kích hoạt
            UpdateVirtualCameraTarget(playerPrefabs[characterIndex].transform);

            Debug.Log("Đã kích hoạt nhân vật với giới tính: " + characterIndex);
        }
        else
        {
            Debug.LogError("Chỉ số nhân vật không hợp lệ: " + characterIndex);
        }
    }
}