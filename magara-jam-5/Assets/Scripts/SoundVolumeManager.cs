using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundVolumeManager : MonoBehaviour
{
    public bool dontDestroyOnLoad;
    public int stopOnThisScene;
    private void Awake()
    {
        if (dontDestroyOnLoad)
        {
            DontDestroyOnLoad(this.gameObject);
            if (SceneManager.GetActiveScene().buildIndex == stopOnThisScene)
            {
                Destroy(this.gameObject);
            }
        }
    }
    private void Start()
    {
        SetVolume();
    }
    public void SetVolume()
    {
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("Volume");
    }
    public void SetVolume(float value)
    {
        GetComponent<AudioSource>().volume = value;
    }
}
