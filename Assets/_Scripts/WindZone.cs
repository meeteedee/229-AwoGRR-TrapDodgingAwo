using UnityEngine;

public class WindZone : MonoBehaviour
{
    public Vector2 windVelocity = new Vector2(-5f, 0f);
    
    public float airDensity = 1.2f;
    public float dragCoefficient = 1.0f;
    public float crossSectionArea = 1.0f;
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            
            if (rb != null)
            {
                Vector2 relativeVelocity = rb.linearVelocity - windVelocity;
                
                float speedSquare = relativeVelocity.sqrMagnitude;
                
                Vector2 dragDirection = -relativeVelocity.normalized; 
                
                float dragMagnitude = 0.5f * airDensity * speedSquare * dragCoefficient * crossSectionArea;
                
                Vector2 dragForce = dragDirection * dragMagnitude;
                
                rb.AddForce(dragForce);
            }
        }
    }
}