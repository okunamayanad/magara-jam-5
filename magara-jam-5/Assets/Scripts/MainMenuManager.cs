using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    [SerializeField] GameObject settingsMenu;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1.0f);
        }
        volumeSlider.value = PlayerPrefs.GetFloat("Volume");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsMenu.activeSelf)
            {
                settingsMenu.SetActive(false);
            }
            else
            {
                settingsMenu.SetActive(true);
            }
        }
    }
    public void VolumeChange()
    {
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        foreach(SoundVolumeManager sound in FindObjectsOfType<SoundVolumeManager>())
        {
            sound.SetVolume(volumeSlider.value);
        } 
    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
