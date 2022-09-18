using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KilitManager : MonoBehaviour
{
    [SerializeField]
    GameObject kilit1;

    [SerializeField]
    GameObject kilit2;

    [SerializeField]
    GameObject kilit3;

    [SerializeField]
    GameObject kilit4;

    // Start is called before the first frame update
    void Start()
    {
        // tüm kilitleri unlockla
        kilit1.GetComponent<kilit>().isLocked = false;
        kilit2.GetComponent<kilit>().isLocked = false;
        kilit3.GetComponent<kilit>().isLocked = false;
        kilit4.GetComponent<kilit>().isLocked = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TryLock()
    {
        Debug.Log("checking if all locks are locked");
        if (
            kilit1.GetComponent<kilit>().isLocked &&
            kilit2.GetComponent<kilit>().isLocked &&
            kilit3.GetComponent<kilit>().isLocked &&
            kilit4.GetComponent<kilit>().isLocked
        )
        {
            SceneTransition.instance.LoadScene(3);
            // change scene
        }
    }
}
