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
    public Dictionary<WeaponType, int> weaponIndexes = new Dictionary<WeaponType, int>();
    public List<WeaponType> weapons = new List<WeaponType>();
    public int currentWeaponIndex;
    public WeaponType currentWeapon;

    [SerializeField] Transform weaponsParent;

    [SerializeField] Material outlineMaterial;
    [SerializeField] Material defaultMaterial;
    GameObject lastOutlined;

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
        weaponIndexes.Add(WeaponType.Knife, 0);
        weaponIndexes.Add(WeaponType.Gun, 1);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        RaycastHit2D outlineHit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction, Mathf.Infinity);
        if (outlineHit)
        {
            InteractiveObject hitObject = outlineHit.collider.gameObject.GetComponent<InteractiveObject>();
            if (hitObject)
            {
                hitObject.gameObject.GetComponent<SpriteRenderer>().material = outlineMaterial;
                lastOutlined = hitObject.gameObject;
            }
        }
        else
        {
            if (lastOutlined != null)
            {
                lastOutlined.GetComponent<SpriteRenderer>().material = defaultMaterial;
                lastOutlined = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(weapons.Count > 0)
            {
                ChangeWeapon();
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction, Mathf.Infinity);
            if (hit)
            {
                InteractiveObject hitObject = hit.collider.gameObject.GetComponent<InteractiveObject>();
                if (hitObject)
                {
                    if (hitObject.m_type == InteractiveObject.ObjectType.Victim)
                    {
                        Shoot(hitObject);
                    }
                    else if (hitObject.m_type == InteractiveObject.ObjectType.Weapon)
                    {
                        AddWeapon(hitObject.m_weaponType);
                        Destroy(hitObject.gameObject);
                    }
                }
            }
        }
    }
    public void AddWeapon(WeaponType weapon)
    {
        if (!weapons.Contains(weapon))
        {
            weapons.Add(weapon);
            ChangeWeapon();
        }
    }
    void ChangeWeapon()
    {
        weaponsParent.GetChild(weaponIndexes[weapons[currentWeaponIndex]]).gameObject.SetActive(false);
        currentWeaponIndex++;
        if(currentWeaponIndex >= weapons.Count)
        {
            currentWeaponIndex = 0;
        }
        weaponsParent.GetChild(weaponIndexes[weapons[currentWeaponIndex]]).gameObject.SetActive(true);
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
