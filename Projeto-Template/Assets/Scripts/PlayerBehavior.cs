using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpSpeed = 5.0f;
    Rigidbody2D rb;
    bool IsGrounded;
    int doubleJump = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movePlayer();
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded && doubleJump > 0)
        {
            jump();
        }
    }

    void movePlayer()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
    }

    void jump()
    {
        doubleJump -= 1;
            rb.velocity = new Vector2(0, jumpSpeed);   
    }

    // Ground Checking and doule jump
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            doubleJump = 2;
            IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground"))
        {
            if(doubleJump == 0){
                IsGrounded = false;
            }
        }
    }
}
