using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaatManager : MonoBehaviour
{
    [SerializeField] GameObject sabah;
    [SerializeField] GameObject gece;

    int targetScene;
    // Start is called before the first frame update
    void Awake()
    {
        targetScene = PlayerPrefs.GetInt("SaatTargetScene");
        int saat = PlayerPrefs.GetInt("SaatTargetSaat");
        if(saat == 0)
        {
            sabah.SetActive(true);
        }
        else
        {
            gece.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadNextScene()
    {
        SceneTransition.instance.LoadScene(targetScene);
    }
}
