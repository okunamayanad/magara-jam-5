using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public enum ObjectType
    {
        Weapon,
        Victim,
        Door,
        HideArea,
        Kagit
    }

    public ObjectType m_type;
    public PlayerWeapon.WeaponType m_weaponType;
    public int m_targetScene;
    public bool saatAnim;
    public bool sabahToGece;
    public GameObject victimKillEvent;
}
