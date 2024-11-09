using UnityEngine;

public class Nieu : MonoBehaviour
{
    public int nieuIndex; 
    public GamePlayDapNieu gamePlayDapNieu;
    public bool hasItem = false;
    private void OnMouseDown()
    {
        if (gamePlayDapNieu != null)
        {
            gamePlayDapNieu.PotClicked(nieuIndex);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra nếu đối tượng va chạm là cây gậy
        if (collision.gameObject.CompareTag("Bat") && gamePlayDapNieu != null)
        {
            Debug.Log("a");
            gamePlayDapNieu.PotClicked(nieuIndex);
        }
    }
}