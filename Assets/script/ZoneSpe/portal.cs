
using UnityEngine;

public class portal : MonoBehaviour
{
    public PlayerController playerController;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("portal2"))
        {
            // Déplacer l'objet vers une nouvelle position
            transform.position = new Vector2(56.5f, -8.5f);

            StartCoroutine(playerController.PauseMovement(1f));
           
        }
        else if (other.CompareTag("portal"))
        {
            // Déplacer l'objet vers une nouvelle position
            transform.position = new Vector2(5.75f, 10.61f);
            StartCoroutine(playerController.PauseMovement(1f));
        
           
        }
    }
}
