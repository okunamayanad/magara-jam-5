using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;

    [SerializeField] GameObject settingsMenu;

    public GameObject lastActive;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Volume"))
        {
            PlayerPrefs.SetFloat("Volume", 1.0f);
        }
        volumeSlider.SetValueWithoutNotify(PlayerPrefs.GetFloat("Volume"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(lastActive)
                lastActive.SetActive(false);
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
    public void Active(GameObject obje)
    {
        obje.SetActive(true);
        lastActive = obje;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
