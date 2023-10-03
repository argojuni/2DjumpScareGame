using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    public float jumpForce = 10f;
    public float doubleJumpForce = 7f;
    public int maxJumps = 2;
    private int jumps = 0;
    private bool isGrounded = false;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.position += new Vector3(horizontalInput * speed * Time.deltaTime, 0, 0);

        if (isGrounded)
        {
            jumps = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumps < maxJumps)
        {
            if (jumps == 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (jumps == 1)
            {
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpForce);
            }

            jumps++;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "trap")
        {
            gameObject.SetActive(false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
