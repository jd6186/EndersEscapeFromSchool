using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int curHealth;

    Rigidbody rigid;
    BoxCollider boxCollider;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gas")
        {
            Gas gas = other.GetComponent<Gas>();
            curHealth -= gas.damage;

            Debug.Log("Gas : " + curHealth);
            if(curHealth < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
