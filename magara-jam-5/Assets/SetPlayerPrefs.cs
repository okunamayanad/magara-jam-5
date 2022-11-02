using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPrefs : MonoBehaviour
{
    public void SetSaat(int value)
    {
        PlayerPrefs.SetInt("SaatTargetSaat", value);
    }
    public void SetTargetScene(int value)
    {
        PlayerPrefs.SetInt("SaatTargetScene", value);
    }
}
