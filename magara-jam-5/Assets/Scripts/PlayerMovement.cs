using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    public bool imMoving;

    Rigidbody2D rb;
    Animator animator;

    [SerializeField] GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
            animator.SetBool("Walk",true);
            if(inputX > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
            imMoving = false;
            animator.SetBool("Walk", false);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }
    }
}
