using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    public bool canClimb = false;
    public bool isClimbing = false;
    public float climbSpeed; // Vitesse de grimpe
    private Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Agripper l'échelle avec la touche "e"
        if (canClimb && Input.GetKeyDown(KeyCode.E))
        {
            isClimbing = !isClimbing; // Alterne entre grimper et arrêter de grimper
            rb.gravityScale = isClimbing ? 0 : 1.5f; // Désactiver ou activer la gravité en fonction de l'état de grimpe
            rb.velocity = Vector2.zero; // Réinitialiser la vélocité pour éviter des mouvements inattendus
        }

        // Gérer le mouvement sur l'échelle
        if (isClimbing)
        {
            float verticalMovement = 0f;

            if (Input.GetKey(KeyCode.W))
            {
                verticalMovement = climbSpeed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                verticalMovement = -climbSpeed;
            }

            rb.velocity = new Vector2(0, verticalMovement);
        }
        
        animator.SetBool("isClimbing", isClimbing);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ladder"))
        {
            canClimb = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ladder"))
        {
            canClimb = false;
            isClimbing = false;
            rb.gravityScale = 1.5f; // Réactiver la gravité quand le joueur quitte l'échelle
        }
    }
}
