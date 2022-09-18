using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraController : MonoBehaviour
{
    [SerializeField]
    bossCamera cam1;

    [SerializeField]
    bossCamera cam2;

    [SerializeField]
    bossCamera cam3;

    [SerializeField]
    bossCamera cam4;

    [SerializeField]
    bossCamera cam5;

    int rnd;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackRandom());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator AttackRandom(){
        yield return new WaitForSeconds(0.5f);
        rnd = Random.Range(1, 5);
        if (rnd == 1) cam1.Attack();
        if (rnd == 2) cam2.Attack();
        if (rnd == 3) cam3.Attack();
        if (rnd == 4) cam4.Attack();
        if (rnd == 5) cam5.Attack();
        yield return new WaitForSeconds(4);
        Start();
    }
}
