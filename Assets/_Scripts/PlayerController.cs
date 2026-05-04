using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 20f;
    public float spinSpeed = 200f;
    
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularDamping = 3f; 
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.AddForce(movement.normalized * moveForce); 
        
        if (movement.x != 0)
        {
            rb.angularVelocity = -movement.x * spinSpeed;
        }
        else if (movement.y != 0)
        {
            rb.angularVelocity = -movement.y * spinSpeed;
        }
    }
}