using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tension : MonoBehaviour
{
    [SerializeField] Transform target;

    AudioSource source;

    public bool cutscene;
    // Start is called before the first frame update
    void Start()
    {
        foreach(SoundVolumeManager manager in FindObjectsOfType<SoundVolumeManager>())
        {
            if (manager.dontDestroyOnLoad)
            {
                source = manager.GetComponents<AudioSource>()[1];
            }
        }
        source.volume = PlayerPrefs.GetFloat("Volume") / 100f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector2.Distance(target.position,transform.position);
        if(distance < 7.5f && !cutscene)
        {
            source.volume = (0.5f / distance);
            source.volume = Mathf.Clamp(source.volume, PlayerPrefs.GetFloat("Volume")/100f, PlayerPrefs.GetFloat("Volume")/2);
        }
    }
    public void GoToCutscene()
    {
        cutscene = true;
        source.volume = PlayerPrefs.GetFloat("Volume");
    }
    public void EndCutscene()
    {
        source.volume = 0f;
    }
}
