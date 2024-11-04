using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCollider : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other) 
   {
      if(other.CompareTag("Player"))
      {
         PointDiCaKheo.Point += 1;
         FindObjectOfType<AudioManager>().Play("Point");
      }   
   }
}
