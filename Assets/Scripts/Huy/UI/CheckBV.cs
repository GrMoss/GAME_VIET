using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;    

public class CheckBV : MonoBehaviour
{
    [SerializeField] private TMP_Text textSlBV1;
    [SerializeField] private TMP_Text textSlBV2;

    private int slBV = 3;

    private void Start()
    {
        CheckSLBV();
    }

    private void FixedUpdate()
    {
        textSlBV1.text = slBV.ToString();
        textSlBV2.text = slBV.ToString();
    }

    private void CheckSLBV()
    {
       foreach (var item in Player.Instance.GetAllItems())
       {
           if (item.IdItem == 13 || item.IdItem == 15)
           {
               slBV += 1;
           }
       }
    }
}
