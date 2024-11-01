using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrail : MonoBehaviour
{
    
    private void FixedUpdate()
    {
        transform.Rotate(0, 0, Time.deltaTime * 10);
    }
}
