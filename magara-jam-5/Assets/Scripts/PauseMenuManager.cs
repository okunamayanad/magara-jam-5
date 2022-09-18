using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MainMenuButton()
    {
        SceneTransition.instance.LoadScene(0);
    }
    public void ExitGameButton()
    {
        Application.Quit();
    }
}
