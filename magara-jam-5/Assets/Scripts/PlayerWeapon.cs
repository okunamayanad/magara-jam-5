using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public enum WeaponType
    {
        Knife,
        Gun
    }
    public List<WeaponType> weapons = new List<WeaponType>();
    public int currentWeaponIndex;
    public WeaponType currentWeapon;

    [SerializeField] Transform weaponsParent;

    public static PlayerWeapon instance;

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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(weapons.Count > 0)
            {
                ChangeWeapon();
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Input.mousePosition, Input.mousePosition - Camera.main.ScreenToWorldPoint(Input.mousePosition), Mathf.Infinity);
            if (hit)
            {
                InteractiveObject hitObject = hit.collider.gameObject.GetComponent<InteractiveObject>();
                if (hitObject.m_type == InteractiveObject.ObjectType.Victim)
                {
                    Shoot(hitObject);
                }
                else if(hitObject.m_type == InteractiveObject.ObjectType.Weapon)
                {
                    AddWeapon(hitObject.m_weaponType);
                    Destroy(hitObject.gameObject);
                }
            }
        }
    }
    public void AddWeapon(WeaponType weapon)
    {
        if (!weapons.Contains(weapon))
        {
            weapons.Add(weapon);
        }
    }
    void ChangeWeapon()
    {
        weaponsParent.GetChild(currentWeaponIndex).gameObject.SetActive(false);
        currentWeaponIndex++;
        if(currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }
        weaponsParent.GetChild(currentWeaponIndex).gameObject.SetActive(true);
        currentWeapon = weapons[currentWeaponIndex];
    }
    void Shoot(InteractiveObject otherObject)
    {
        if(currentWeapon == WeaponType.Knife)
        {

        }
        else if(currentWeapon == WeaponType.Gun)
        {

        }
    }
}
