using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(credits());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator credits()
    {
        yield return new WaitForSeconds(20);
        SceneManager.LoadScene(0);
    }
}
