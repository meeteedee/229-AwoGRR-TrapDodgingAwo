using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapController : MonoBehaviour
{
    public float bounceForce = 10f;
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("hp-1");

            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb != null)
            {
                Vector2 bounceDirection = (collision.transform.position - transform.position).normalized;
                
                playerRb.linearVelocity = Vector2.zero; 
                playerRb.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
            }

        }
    }
}