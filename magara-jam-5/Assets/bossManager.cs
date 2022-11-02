using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bossManager : MonoBehaviour
{
    [SerializeField]
    Animator cameraAnimator;

    [SerializeField]
    Transform cameratrans;

    [SerializeField]
    Slider P1slider;

    [SerializeField]
    Slider P2slider;

    [SerializeField]
    kameraController kameraController;

    public int P1health = 250;

    public int P2health = 100;

    int rnd;

    public void Damage(int player)
    {
        if (player == 1)
        {
            // P1
            P1health -= Random.Range(10, 20);
        }
        else
        {
            // P2
            P2health -= Random.Range(1, 10);
        }
    }

    private void Start()
    {
        cameraAttack();
    }

    void cameraAttack()
    {
        StartCoroutine(cameraAttackASYNC());
        StartCoroutine(cameraAttackASYNC());
        StartCoroutine(cameraAttackASYNC());
        StartCoroutine(cameraAttackASYNC());
        StartCoroutine(cameraAttackASYNC());
        StartCoroutine(cameraAttackASYNC());
        StartCoroutine(cameraAttackASYNC());
        StartCoroutine(cameraAttackASYNC());    
    }

    IEnumerator cameraAttackASYNC()
    {
        StartCoroutine(kameraController.AttackRandom());
        yield return new WaitForSeconds(2.5f);
        cameraAnimator.enabled = true;
        yield return new WaitForSeconds(1.5f);
        cameraAnimator.enabled = false;
        cameratrans.rotation = new Quaternion(0f, 0f, 0f, 0f);
        cameratrans.position = new Vector3(0f, 0f, -10f);
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(cameraAttackASYNC());
    }

    // Update is called once per frame
    void Update()
    {
        P1slider.value = P1health;
        P2slider.value = P2health;

        if (P1health <= 0)
        {
            // P1 ded
            P1health = 0;
            Debug.Log("P1 ded");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (P2health <= 0)
        {
            // P2 ded
            P2health = 0;
            Debug.Log("P2 ded");
            SceneManager.LoadScene(13);
        }
    }
}
