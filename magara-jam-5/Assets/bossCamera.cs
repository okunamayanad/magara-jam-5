using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossCamera : MonoBehaviour
{
    public SpriteRenderer spriteRndrr;

    public Sprite redCam;

    public Sprite normalCam;

    public GameObject unlem;

    public GameObject beam;

    [SerializeField]
    private GameObject attackLight;

    private void Start()
    {
        unlem.SetActive(false);
        beam.SetActive(false);
        attackLight.SetActive(false);
        // Attack();
    }

    public void Attack()
    {
        unlem.SetActive(true);
        attackLight.SetActive(true);
        spriteRndrr.sprite = redCam;
        StartCoroutine(AttackASYNC());
    }

    IEnumerator AttackASYNC()
    {
        yield return new WaitForSeconds(2.5f);
        unlem.SetActive(false);
        beam.SetActive(true);

        // ses efekti
        yield return new WaitForSeconds(1.5f);
        beam.SetActive(false);
        spriteRndrr.sprite = normalCam;
        attackLight.SetActive(false);
    }
}
