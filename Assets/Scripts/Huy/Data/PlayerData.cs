using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int A;
    public int B;
    public float[] position;
    
    // Thêm các thuộc tính mới
    public List<int> items;
    public int score;

    public PlayerData(Player player)
    {
        A = player.A;
        B = player.B;
        
        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        // Gán dữ liệu của items và điểm số
        items = new List<int>(player.items);
        score = player.score;
    }
}
