
using UnityEngine;

public class PointFaible : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
                Destroy(transform.parent.parent.gameObject);
        }
        
    }
        
}
