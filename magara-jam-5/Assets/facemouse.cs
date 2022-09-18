using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facemouse : MonoBehaviour
{
    [SerializeField]
    Transform point;
    
    void Update()
    {
        Vector3 dir = Input.mousePosition - Camera.main.ScreenToWorldPoint(transform.position);
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,angle+(-90));
        /*
        Vector2 direction =
            new Vector2(mousePos.x - point.position.x,
                mousePos.y - point.position.y);

        transform.up = direction;*/
    }
}
