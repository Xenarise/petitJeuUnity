
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public bool died = false;
    private Vector2 originalvector2;
    public PlayerHealth playerHealth;

    
    void Start(){
        originalvector2 = transform.localPosition;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // Vérifie si l'objet entrant en collision a le tag "surface"
        if (other.CompareTag("surface"))
        {
            died = true;
            if (died)
            {
                transform.position = originalvector2;
                playerHealth.TakeDamage(40);
                if (playerHealth.curentHealth <= 0){
                    playerHealth.healthBar.SetHealth(playerHealth.MaxHealth);
                }
                died = false;
            }
        }
    }
    
}