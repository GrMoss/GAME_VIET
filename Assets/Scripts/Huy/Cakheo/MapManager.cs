using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public SpawnBox spawnBox;
    public Scrolling scrolling;

    void Start()
    {
        
    }

    private void FixedUpdate() 
    {

        if(PiontDiCaKheo.Point == 3)
        {
            spawnBox.spawnInterval = 3;
        }
        else if(PiontDiCaKheo.Point == 5)
        {
            spawnBox.spawnInterval = 2.5f;
        }
        else if(PiontDiCaKheo.Point == 10)
        {
            spawnBox.spawnInterval = 2;
        }
        else if(PiontDiCaKheo.Point == 20)
        {
            spawnBox.spawnInterval = 2.5f;
        }
        else if(PiontDiCaKheo.Point == 30)
        {
            spawnBox.spawnInterval = 2;
        }
        else if(PiontDiCaKheo.Point == 40)
        {
            spawnBox.spawnInterval = 1.5f;
        } 
        else if(PiontDiCaKheo.Point == 50)
        {
            spawnBox.spawnInterval = 1;
        }

     

    }
}
