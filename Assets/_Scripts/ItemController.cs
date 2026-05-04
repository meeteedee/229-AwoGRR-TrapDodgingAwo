using UnityEngine;

public class ItemController : MonoBehaviour
{
    public int itemScore = 10;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // ถ้าคนที่มาชนมี Tag ว่า Player
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(itemScore);
            
            Destroy(gameObject);
        }
    }
}