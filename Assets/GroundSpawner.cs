using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    public float minDistance = 2f;

    private Rigidbody2D rb;
    private Vector2 moveDirection;

    public GameObject ground1, ground2, ground3;
    bool hasGround = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasGround)
        {
            SpawnGround();
            hasGround = true;
        }
    }

    void FixedUpdate()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance <= minDistance)
        {
            moveDirection = (transform.position - player.position).normalized;
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        }
    }
    public void SpawnGround()
    {
        int randomNum = Random.Range(1, 4);
        if(randomNum == 1)
        {
            Instantiate(ground1, new Vector3(4.4f, transform.position.y + 3, 0),Quaternion.identity);
        }
        if (randomNum == 2)
        {
            Instantiate(ground2, new Vector3(-1.59f, transform.position.y + 3, 0), Quaternion.identity);
        }
        if (randomNum == 3)
        {
            Instantiate(ground3, new Vector3(-0.12f, transform.position.y + 3, 0), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            hasGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasGround = false;
        }
    }
}
