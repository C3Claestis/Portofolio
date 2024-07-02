using System;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private float speed = 5f;
    private float jumpForce = 10f;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // // Check if player is on the ground
        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // // Handle jump input
        // if (isGrounded && Input.GetButtonDown("Jump"))
        // {
        //     rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        // }
    }

    void FixedUpdate()
    {
        float dirX = Input.GetAxis("Horizontal");
        float dirY = Input.GetAxis("Vertical");
        // Move the player
        rigidbody2D.velocity = new Vector2(dirX * speed, dirY * speed);

        //Clamp posisi
        float clampY = Math.Clamp(transform.position.y, -5f, 0);
        transform.position = new Vector2(transform.position.x, clampY);

        // Check direction and flip sprite if necessary
        if (dirX > 0 && !facingRight)
        {
            Flip();
        }
        else if (dirX < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
