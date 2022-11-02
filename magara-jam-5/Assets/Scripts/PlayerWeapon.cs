using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWeapon : MonoBehaviour
{
    public enum WeaponType
    {
        Null,
        Knife,
        Gun
    }
    public Dictionary<WeaponType, int> weaponIndexes = new Dictionary<WeaponType, int>();
    public List<WeaponType> weapons = new List<WeaponType>();
    public int currentWeaponIndex;
    public WeaponType currentWeapon;

    [SerializeField] Transform weaponsParent;
    [SerializeField] bool giveWeaponOnStart;

    [SerializeField] Material outlineMaterial;
    [SerializeField] Material defaultMaterial;
    GameObject lastOutlined;

    public bool imHided;

    [SerializeField] Animator nullWeaponAlert;

    [SerializeField] int kagitCount;
    [SerializeField] int totalKagit;
    [SerializeField] GameObject puzzleScreen;

    [SerializeField] Camera cam;

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
        if(cam == null)
        {
            cam = Camera.main;
        }
        if (giveWeaponOnStart)
        {
            if(currentWeapon == WeaponType.Gun)
            {
                gameObject.GetComponent<Animator>().SetBool("Gun", true);
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Outline Object
        RaycastHit2D outlineHit = Physics2D.Raycast(cam.ScreenPointToRay(Input.mousePosition).origin, cam.ScreenPointToRay(Input.mousePosition).direction, Mathf.Infinity, imHided ? LayerMask.GetMask("InteractiveObject/HideArea") : LayerMask.GetMask("InteractiveObject/InteractiveObject", "InteractiveObject/HideArea"));
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(cam.ScreenPointToRay(Input.mousePosition).origin, cam.ScreenPointToRay(Input.mousePosition).direction, Mathf.Infinity);
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
                            if (hitObject.saatAnim)
                            {
                                PlayerPrefs.SetInt("SaatTargetScene",hitObject.m_targetScene);
                                if (hitObject.sabahToGece)
                                {
                                    PlayerPrefs.SetInt("SaatTargetSaat", 0);
                                }
                                else
                                {
                                    PlayerPrefs.SetInt("SaatTargetSaat", 1);
                                }
                                SceneTransition.instance.LoadScene(14);
                            }
                            else
                            {
                                SceneTransition.instance.LoadScene(hitObject.m_targetScene);
                            }
                            break;
                        case InteractiveObject.ObjectType.HideArea:
                            Hide(hitObject);
                            break;
                        case InteractiveObject.ObjectType.Kagit:
                            totalKagit++;
                            Destroy(hitObject.gameObject);
                            if(totalKagit == kagitCount)
                            {
                                puzzleScreen.SetActive(true);
                            }
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
        currentWeapon = weapon;
        if(weapon == WeaponType.Knife)
        {
            gameObject.GetComponent<Animator>().SetBool("Knife",true);
        }
    }
    void Shoot(InteractiveObject otherObject)
    {
        if(currentWeapon == WeaponType.Knife)
        {
            this.gameObject.SetActive(false);
            otherObject.victimKillEvent.SetActive(true);
            if (lastOutlined != null)
            {
                lastOutlined.GetComponent<SpriteRenderer>().material = defaultMaterial;
                lastOutlined = null;
            }
        }
        else if(currentWeapon == WeaponType.Gun)
        {
            this.gameObject.SetActive(false);
            otherObject.victimKillEvent.SetActive(true);
            if (lastOutlined != null)
            {
                lastOutlined.GetComponent<SpriteRenderer>().material = defaultMaterial;
                lastOutlined = null;
            }
        }
        else if(currentWeapon == WeaponType.Null)
        {
            nullWeaponAlert.SetTrigger("Play");
        }
    }
    public void LoadScene(int sceneIndex)
    {
        SceneTransition.instance.LoadScene(sceneIndex);
    }
}
