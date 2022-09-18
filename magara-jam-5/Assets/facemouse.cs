using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class facemouse : MonoBehaviour
{
    [SerializeField]
    Transform point;
    
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector2 direction =
            new Vector2(mousePos.x - point.position.x,
                mousePos.y - point.position.y);

        transform.up = direction;
    }
}
