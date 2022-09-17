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

    public bool imHided;

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
        //Outline Object
        RaycastHit2D outlineHit = Physics2D.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction, Mathf.Infinity, imHided ? LayerMask.GetMask("InteractiveObject/HideArea") : LayerMask.GetMask("InteractiveObject/InteractiveObject", "InteractiveObject/HideArea"));
        if (outlineHit && Vector2.Distance(transform.position,outlineHit.transform.position)<3)
        {
            InteractiveObject hitObject = outlineHit.collider.gameObject.GetComponent<InteractiveObject>();
            if (hitObject)
            {
                if (lastOutlined != null)
                {
                    lastOutlined.GetComponent<SpriteRenderer>().material = defaultMaterial;
                    lastOutlined = null;
                }
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
        //End Outline Object

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
            if (hit && Vector2.Distance(transform.position, outlineHit.transform.position) < 3)
            {
                InteractiveObject hitObject = hit.collider.gameObject.GetComponent<InteractiveObject>();
                if (hitObject)
                {
                    switch (hitObject.m_type)
                    {
                        case InteractiveObject.ObjectType.Weapon:
                            AddWeapon(hitObject.m_weaponType);
                            Destroy(hitObject.gameObject);
                            break;
                        case InteractiveObject.ObjectType.Victim:
                            Shoot(hitObject);
                            break;
                        case InteractiveObject.ObjectType.Door:
                            SceneTransition.instance.LoadScene(hitObject.m_targetScene);
                            break;
                        case InteractiveObject.ObjectType.HideArea:
                            Hide(hitObject);
                            break;
                    }
                }
            }
        }
    }
    public void Hide(InteractiveObject otherObject)
    {
        if (!imHided)
        {
            imHided = true;
            otherObject.transform.GetChild(0).gameObject.SetActive(true);
            otherObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Crouch", true);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
            transform.position = new Vector2(otherObject.transform.position.x - 0.5f, transform.position.y);
        }
        else
        {
            imHided = false;
            otherObject.transform.GetChild(0).gameObject.SetActive(false);
            otherObject.transform.GetChild(0).GetComponent<Animator>().SetBool("Crouch", false);
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Rigidbody2D>().simulated = true;
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
