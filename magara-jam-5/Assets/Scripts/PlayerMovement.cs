using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    public bool imMoving;

    Rigidbody2D rb;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if(inputX != 0)
        {
            rb.velocity = new Vector2(inputX * movementSpeed, 0);
            imMoving = true;
            //animator.SetBool("Move",true);
        }
        else
        {
            rb.velocity = Vector2.zero;
            imMoving = false;
            //animator.SetBool("Move", false);
        }
    }
}
