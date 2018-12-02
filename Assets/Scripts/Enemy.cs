using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public BarScript[] target;
    public bool isMeleeAttacking;
    public int activeTarget = 1;


    // Use this for initialization
    void Start()
    {
        isMeleeAttacking = true;
        StartCoroutine(Melee());
        StartCoroutine(Blast());
    }


    // Update is called once per frame
    void Update()
    {
        //Debug.Log(isMeleeAttacking);
    }

    private void HitTarget(int id, int jakMocno)
    {   
       target[id].currentHP -= jakMocno;
        Debug.Log("uderzam target nr: " + id);
    }

    public IEnumerator Blast()
    {
        yield return new WaitForSeconds(8);
        for (int i = 0; i < target.Length; i++)
        {
            HitTarget(i, 20);
           // Debug.Log("uderzam target nr: " + i);
        }
        StartCoroutine(Blast());
    }

    public IEnumerator Melee()
    {
        yield return new WaitForSeconds(1);
        if (isMeleeAttacking == true) HitTarget(activeTarget, 10);
        StartCoroutine(Melee());
    }
}
