using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineNearObjects : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("InteractiveObject"))
        {
            collision.GetComponent<SpriteRenderer>().sprite = collision.GetComponent<InteractiveObject>().m_outlined;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("InteractiveObject"))
        {
            collision.GetComponent<SpriteRenderer>().sprite = collision.GetComponent<InteractiveObject>().m_original;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
