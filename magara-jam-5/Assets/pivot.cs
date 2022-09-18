using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pivot : MonoBehaviour
{
    [SerializeField]
    private Transform gunTip;

    [SerializeField]
    private GameObject mermi;

    [SerializeField]
    private GameObject isik;

    public float cooldownTime;

    float nextFireTime;

    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(isik,
                new Vector3(gunTip.position.x,
                    gunTip.position.y,
                    gunTip.position.z),
                transform.rotation);
                Instantiate(mermi,
                new Vector3(gunTip.position.x,
                    gunTip.position.y,
                    gunTip.position.z),
                transform.rotation);
                nextFireTime = Time.time + cooldownTime;
            }
        }
    }

    void FixedUpdate()
    {
        Vector3 difference =
            Camera.main.ScreenToWorldPoint(Input.mousePosition) -
            transform.position;

        difference.Normalize();

        float rotationZ =
            Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
}
