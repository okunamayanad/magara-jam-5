using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maymunplayer : MonoBehaviour
{
    [SerializeField]
    float movementSpeed;

    [SerializeField]
    Rigidbody2D rb;

    void FixedUpdate()
    {
        
        float inputX = Input.GetAxis("Horizontal");
        
        float inputY = Input.GetAxis("Vertical");
        if (inputX != 0 || inputY != 0)
        {
            rb.velocity =
                new Vector2(inputX * movementSpeed, inputY * movementSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
