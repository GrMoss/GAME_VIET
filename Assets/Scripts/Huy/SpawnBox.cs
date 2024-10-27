using System.Collections;
using System.Collections.Generic;
using System.Linq; // Đảm bảo thêm thư viện này
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public enum SpawnDirection
    {
       Right, Left, Up, Down
    }

    [Header("Spawn Points")]
    public Transform pointA; 
    public Transform pointB; 

    [Header("Spawn Objects")]
    public List<GameObject> spawnableObjects = new List<GameObject>();

    [Header("Spawn Settings")]
    public bool spawnRandom = true;
    [Range(0, 100)] public int spawnCount = 10;
    public bool unlimitedSpawn = false;
    public int fixedIndex = 0;
    [SerializeField] private float spawnInterval = 1f;
    [SerializeField] private float objectActiveTime = 3f;

    // Tốc độ spawn được điều chỉnh qua Inspector
    public float spawnSpeed = 2f; // Tốc độ di chuyển của object khi được spawn

    // Hướng spawn
    public SpawnDirection spawnDirection;

    private Queue<GameObject> objectPool = new Queue<GameObject>();

    void Start()
    {
        if (pointA == null || pointB == null || spawnableObjects.Count == 0)
        {
            Debug.LogError("Vui lòng thiết lập các điểm A, B và các đối tượng để spawn.");
            return;
        }

        InitializeObjectPool();
        StartCoroutine(SpawnItems());
    }

    private void InitializeObjectPool()
    {
        foreach (var obj in spawnableObjects)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                GameObject pooledObj = Instantiate(obj);
                pooledObj.SetActive(false);
                pooledObj.AddComponent<SpawnableObject>().SetPool(this); // Thêm component để xử lý va chạm
                objectPool.Enqueue(pooledObj);
            }
        }
    }

    private IEnumerator SpawnItems()
    {
        int spawnedItems = 0;

        while (unlimitedSpawn || spawnedItems < spawnCount)
        {
            float randomPosition = Random.Range(0f, 1f);
            Vector3 spawnPoint = Vector3.Lerp(pointA.position, pointB.position, randomPosition);

            GameObject objectToSpawn = GetObjectFromPool();
            if (objectToSpawn != null)
            {
                objectToSpawn.transform.position = spawnPoint;
                objectToSpawn.SetActive(true);

                // Thiết lập tốc độ và hướng cho SpawnableObject
                SpawnableObject spawnableObj = objectToSpawn.GetComponent<SpawnableObject>();
                spawnableObj.SetSpeedAndDirection(GetDirectionVector(), spawnSpeed); // Sử dụng tốc độ đã chỉnh sửa

                StartCoroutine(ReturnToPoolAfterTime(objectToSpawn, objectActiveTime));
            }

            if (!unlimitedSpawn)
                spawnedItems++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private GameObject GetObjectFromPool()
    {
        if (objectPool.Count > 0)
        {
            // Lấy tất cả các đối tượng trong queue vào một danh sách
            List<GameObject> availableObjects = new List<GameObject>(objectPool);
            // Chọn ngẫu nhiên một đối tượng từ danh sách
            int randomIndex = Random.Range(0, availableObjects.Count);
            GameObject selectedObject = availableObjects[randomIndex];
            
            // Đảm bảo rằng chúng ta xóa đối tượng đã chọn khỏi queue
            objectPool = new Queue<GameObject>(objectPool.Where(obj => obj != selectedObject)); 
            return selectedObject;
        }
        return null;
    }

    private IEnumerator ReturnToPoolAfterTime(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        ReturnObjectToPool(obj);
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }

    private Vector2 GetDirectionVector()
    {
        // Chọn hướng dựa trên giá trị trong Inspector
        switch (spawnDirection)
        {
            case SpawnDirection.Right:
                return Vector2.right; // Hướng x
            case SpawnDirection.Left:
                return Vector2.left;  // Hướng -x
            case SpawnDirection.Up:
                return Vector2.up;    // Hướng y
            case SpawnDirection.Down:
                return Vector2.down;  // Hướng -y
            default:
                return Vector2.zero;   // Mặc định
        }
    }
}