using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnBox : MonoBehaviour
{
    public enum SpawnDirection
    {
        Right, Left, Up, Down
    }

    public enum SpawnLocation
    {
        RandomInAtoB, // Vị trí ngẫu nhiên trong khoảng từ A đến B
        PointC // Tại vị trí C
    }

    [Header("Spawn Points")]
    public Transform pointA; 
    public Transform pointB; 
    public Transform pointC; // Điểm spawn C mới

    [Header("Spawn Objects")]
    public List<GameObject> spawnableObjects = new List<GameObject>();

    [Header("Spawn Settings")]
    public bool spawnRandom = true;
    public SpawnLocation spawnLocation; // Tùy chọn vị trí spawn
    [Range(0, 100)] public int spawnCount = 10;
    public bool unlimitedSpawn = false;
    public int fixedIndex = 0;
    public float spawnInterval = 1f;
    [SerializeField] private float objectActiveTime = 3f;

    public float spawnSpeed = 2f; // Tốc độ di chuyển của object khi được spawn
    public SpawnDirection spawnDirection;

    private Queue<GameObject> objectPool = new Queue<GameObject>();

    void Start()
    {
        if (spawnableObjects.Count == 0 || 
            (spawnLocation == SpawnLocation.RandomInAtoB && (pointA == null || pointB == null)) ||
            (spawnLocation == SpawnLocation.PointC && pointC == null))
        {
            Debug.LogError("Vui lòng thiết lập các điểm spawn và các đối tượng để spawn.");
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
            Vector3 spawnPoint;

            // Chọn vị trí spawn dựa trên tùy chọn
            if (spawnLocation == SpawnLocation.RandomInAtoB && pointA != null && pointB != null)
            {
                float randomPosition = Random.Range(0f, 1f);
                spawnPoint = Vector3.Lerp(pointA.position, pointB.position, randomPosition);
            }
            else if (spawnLocation == SpawnLocation.PointC && pointC != null)
            {
                spawnPoint = pointC.position;
            }
            else
            {
                Debug.LogWarning("Điểm spawn không hợp lệ.");
                yield break; // Kết thúc vòng lặp nếu không có điểm spawn hợp lệ
            }

            GameObject objectToSpawn = GetObjectFromPool();
            if (objectToSpawn != null)
            {
                objectToSpawn.transform.position = spawnPoint;
                objectToSpawn.SetActive(true);

                // Thiết lập tốc độ và hướng cho SpawnableObject
                SpawnableObject spawnableObj = objectToSpawn.GetComponent<SpawnableObject>();
                spawnableObj.SetSpeedAndDirection(GetDirectionVector(), spawnSpeed);

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
            List<GameObject> availableObjects = new List<GameObject>(objectPool);
            int randomIndex = Random.Range(0, availableObjects.Count);
            GameObject selectedObject = availableObjects[randomIndex];
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
        switch (spawnDirection)
        {
            case SpawnDirection.Right:
                return Vector2.right;
            case SpawnDirection.Left:
                return Vector2.left;
            case SpawnDirection.Up:
                return Vector2.up;
            case SpawnDirection.Down:
                return Vector2.down;
            default:
                return Vector2.zero;
        }
    }
}