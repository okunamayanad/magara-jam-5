using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitle : MonoBehaviour
{
    public GameObject nextEvent;
     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            nextEvent.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
