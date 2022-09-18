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

    int rnd;
    public IEnumerator AttackRandom(){
        rnd = Random.Range(1, 5);
        if (rnd == 1) cam1.Attack();
        if (rnd == 2) cam2.Attack();
        if (rnd == 3) cam3.Attack();
        if (rnd == 4) cam4.Attack();
        yield return new WaitForSeconds(4);
    }
}
