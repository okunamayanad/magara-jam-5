using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kilit : MonoBehaviour
{
    [SerializeField]
    private Transform transform;

    [SerializeField]
    private Rigidbody2D rb;

    public bool isLocked;

    [SerializeField]
    ParticleSystem ps;

    bool inTrigger;

    [SerializeField]
    GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        // rb = this.Rigidbody2D;
        // transform = this.Transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("pressed space");
            if (inTrigger)
            {
                Debug.Log("in trigger");
                Try();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inTrigger = false;
    }

    public void Try()
    {
        Debug.Log("trying rn pos y: " + transform.position.y);
        if (transform.position.y <= 0.1f && transform.position.y >= -0.5f)
        {
            Debug.Log("going to lock");
            transform.position =
                new Vector3(transform.position.x, -0.1f, transform.position.z);
            rb.simulated = false;
            isLocked = true;
            GM.GetComponent<KilitManager>().TryLock();
            ps.Play();
        }
    }
}
