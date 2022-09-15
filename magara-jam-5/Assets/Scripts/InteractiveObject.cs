using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public enum ObjectType
    {
        Weapon,
        Victim,
    }

    public ObjectType m_type;
    public PlayerWeapon.WeaponType m_weaponType;
    public Sprite m_original;
    public Sprite m_outlined;
}
