using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;

    Rigidbody2D m_Rigidbody;

    [SerializeField]
    bossManager bossManager;

    // Start is called before the first frame update
    void Start()
    {
        bossManager =
            GameObject.Find("bossmanager").GetComponent<bossManager>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_Rigidbody.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "dost")
        {
            bossManager.Damage(2);
        }
        else if (col.gameObject.name == "player")
        {
            bossManager.Damage(1);
        }
        Destroy (gameObject);
    }
}
