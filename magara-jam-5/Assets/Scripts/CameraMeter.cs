using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMeter : MonoBehaviour
{
    public float meter;
    public bool imInCam;

    [SerializeField] Image meterEffect;

    public static CameraMeter instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (imInCam)
        {
            meter += Time.deltaTime;
            meter = Mathf.Clamp(meter, 0, 0.5f);
            meterEffect.color = new Color(255,0,0,meter/2);
            if(meter >= 0.5f)
            {
                foreach (SoundVolumeManager manager in FindObjectsOfType<SoundVolumeManager>())
                {
                    if (manager.dontDestroyOnLoad)
                    {
                        Destroy(manager.gameObject);
                    }
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
        else
        {
            meter -= Time.deltaTime;
            meter = Mathf.Clamp(meter, 0, 0.5f);
            meterEffect.color = new Color(255, 0, 0, meter / 2);
        }
    }
}
