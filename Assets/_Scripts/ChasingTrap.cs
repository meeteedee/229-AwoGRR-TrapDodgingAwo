using UnityEngine;

public class ChasingTrap : MonoBehaviour
{
    public float speed = 2f;
    public float chaseRadius = 5f;
    
    public float bounceForce = 10f;

    private Transform player;
    private Rigidbody2D rb;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player == null) return;
        
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distanceToPlayer <= chaseRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            
            rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
        }
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.TakeDamage();

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