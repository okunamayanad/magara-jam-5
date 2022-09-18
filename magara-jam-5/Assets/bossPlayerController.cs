using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [SerializeField]
    bool isMoving;

    [SerializeField]
    bool isEgiling;

    [SerializeField]
    Animator animator;  
    [SerializeField]
    GameObject pivot;  

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("jumping");
            rb.velocity = Vector2.up * jumpSpeed;
        }
        if (inDanger)
        {
            bossMan.Damage(1);
        }
        animator.SetBool("isEgiling", isEgiling);
        animator.SetBool("isMoving", isMoving);
    }

    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal"); 
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            isEgiling = true;
            pivot.SetActive(false);
        }
        else
        {
            pivot.SetActive(true);
            isEgiling = false;
            if (inputX != 0)
            {
                isMoving = true;
                rb.velocity =
                    new Vector2(inputX * movementSpeed, rb.velocity.y);
            }
            else
            {
                isMoving = false;
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
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
