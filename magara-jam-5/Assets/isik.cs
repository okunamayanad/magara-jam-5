using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isik : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartASYNC());
    }

    IEnumerator StartASYNC()
    {
        yield return new WaitForSeconds(0.02f);
        Destroy (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
