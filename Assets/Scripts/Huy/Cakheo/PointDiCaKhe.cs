using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Drawing;

public class PiontDiCaKheo : MonoBehaviour
{
    public TMP_Text textPoint;
    public static int Point;

    void Start()
    {
        Point = 0;
    }

    private void FixedUpdate() 
    {
        textPoint.text = Point.ToString();
    }
}
