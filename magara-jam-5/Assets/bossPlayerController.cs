using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossPlayerController : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    public float jumpSpeed;

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    bossManager bossMan;

    bool inDanger;

    float targetJumpTime;
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(Time.time > targetJumpTime)
            {
                Debug.Log("jumping");
                rb.velocity = Vector2.up * jumpSpeed;
                targetJumpTime = Time.time + 2;
            }
        }
        if (inDanger)
        {
            bossMan.P1health -= 1;
        }
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        if (inputX != 0)
        {
            rb.velocity = new Vector2(inputX * movementSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inDanger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            inDanger = false;
        }
    }

    public void die()
    {
    }
}
