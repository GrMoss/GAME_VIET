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
    private Vector3 startPosition;
    private bool isFlying = false;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (!isFlying)
        {
            float x = Mathf.PingPong(Time.time * moveSpeed, moveDistance) - moveDistance / 2;
            transform.position = new Vector3(startPosition.x + x, startPosition.y, startPosition.z);
        }
    }

    public void OnButtonPress()
    {
        if (!isFlying)
            StartCoroutine(FlyAndReturn());
    }

    private IEnumerator FlyAndReturn()
    {
        isFlying = true;
        Vector3 targetPosition = new Vector3(transform.position.x, startPosition.y + posTarget, transform.position.z);
        float elapsedTime = 0f;

        while (elapsedTime < flyTime)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, (elapsedTime / flyTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

        elapsedTime = 0f;
        while (elapsedTime < flyTime)
        {
            transform.position = Vector3.Lerp(transform.position, startPosition, (elapsedTime / flyTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        isFlying = false;
    }
}