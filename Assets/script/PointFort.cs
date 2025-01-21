
using UnityEngine;

public class PointFort : MonoBehaviour
{
    private Vector2 originalvector2;
    public PlayerHealth playerHealth;
    void Start(){
        
        originalvector2 = transform.localPosition;
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("pointf"))
        {
                transform.position = originalvector2;
                playerHealth.TakeDamage(50);
                
        }
    }
}
