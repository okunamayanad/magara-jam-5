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

    [SerializeField]
    bossCamera cam6;

    [SerializeField]
    bossCamera cam7;

    [SerializeField]
    bossCamera cam8;

    [SerializeField]
    bossCamera cam9;

    [SerializeField]
    bossCamera cam10;

    [SerializeField]
    bossCamera cam11;

    [SerializeField]
    bossCamera cam12;

    [SerializeField]
    bossCamera cam13;

    [SerializeField]
    bossCamera cam14;

    [SerializeField]
    bossCamera cam15;

    int rnd;

    public IEnumerator AttackRandom()
    {
        rnd = Random.Range(1, 16);
        if (rnd == 1) cam1.Attack();
        if (rnd == 2) cam2.Attack();
        if (rnd == 3) cam3.Attack();
        if (rnd == 4) cam4.Attack();
        if (rnd == 5) cam5.Attack();
        if (rnd == 6) cam6.Attack();
        if (rnd == 7) cam7.Attack();
        if (rnd == 8) cam8.Attack();
        if (rnd == 9) cam9.Attack();
        if (rnd == 10) cam10.Attack();
        if (rnd == 11) cam11.Attack();
        if (rnd == 12) cam12.Attack();
        if (rnd == 13) cam13.Attack();
        if (rnd == 14) cam14.Attack();
        if (rnd == 15) cam15.Attack();
        yield return new WaitForSeconds(4);
    }
}
