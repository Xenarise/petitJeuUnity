using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    private bool isGrounded = false;
    private bool canJump = true;
    public bool canMove =true;
    private bool walkOnWall = false;
    

    private Rigidbody2D rb;
    private Collider2D coll;

    public Animator animator;
    public SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
    }
    
    public void Update()
    {
        
        if (canMove){

        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Handle jump
        if (Input.GetButtonDown("Jump") && isGrounded && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            canJump = false; // Prevent multiple jumps
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = Vector2.down * jumpForce;
        }
        if (Input.GetKeyDown(KeyCode.Q)){
            walkOnWall = !walkOnWall;
            rb.gravityScale = walkOnWall ? -2: 1.5f;
            if (walkOnWall == false)
            transform.eulerAngles = new Vector3(0, 0, 0);
            else if (walkOnWall == true){
                transform.eulerAngles = new Vector3(180f, 0, 0);
            }

        }

        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is grounded
        if (collision.contacts.Length > 0)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f)
                {
                    isGrounded = true;
                    canJump = true; // Allow jumping again when grounded
                }
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player leaves the ground
        if (collision.contacts.Length > 0)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (Vector2.Dot(contact.normal, Vector2.up) > 0.5f)
                {
                    isGrounded = false;
                }
            }
        }
    }
    void Flip(float _velocity){
            if(_velocity > 0.1f){
                spriteRenderer.flipX = false;
            }
            else if(_velocity < -0.1f){
                spriteRenderer.flipX = true;
            }
    }

    public IEnumerator PauseMovement(float duration)
    {
        canMove = false;
        rb.velocity = Vector2.zero; // Arrêter le mouvement immédiatement
        yield return new WaitForSeconds(duration);
        canMove = true;
    }
}
