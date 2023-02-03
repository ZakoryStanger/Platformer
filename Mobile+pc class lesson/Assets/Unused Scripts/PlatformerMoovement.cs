using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMoovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float jumpSpeed = 1.0f;
    bool grounded = false;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        Vector2 volocity = rb.velocity;
        volocity.x = movex * moveSpeed;
        rb.velocity = volocity;
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            animator.SetTrigger("PlayerJump");
        }
        if(rb.velocity.y < -0.1f && !grounded)
        {
            animator.SetTrigger("PFall");
        }
        animator.SetFloat("xInput", movex);
        animator.SetBool("grounded", grounded);
        if(movex < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(movex > 0)
        {
            spriteRenderer.flipX =false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
}