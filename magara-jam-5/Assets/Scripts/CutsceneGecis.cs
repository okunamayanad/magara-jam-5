using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneGecis : MonoBehaviour
{
    [SerializeField] GameObject[] deactiveThisObjects;
    [SerializeField] GameObject[] activeThisObjects;

    public bool loadScene;
    public int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject obje in deactiveThisObjects)
        {
            obje.SetActive(false);
        }
        foreach(GameObject obje in activeThisObjects)
        {
            obje.SetActive(true);
        }
        if (loadScene)
        {
            SceneTransition.instance.LoadScene(sceneIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
