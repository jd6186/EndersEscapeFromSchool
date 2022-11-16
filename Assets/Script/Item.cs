using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public enum Type {Gas};
    public Type type;
    public int damage;
    public float rate;

    public int maxGas;
    public int curGas;

    public BoxCollider meleeArea;
    public TrailRenderer trailEffect;
    
    public Transform gasPosition;
    public GameObject gas;

    public void Use()
    {
        if(type == Type.Gas && curGas > 0)
        {
            curGas--;
            StartCoroutine("Shot");
        }
    }

    IEnumerator Shot()
    {
        //#1. 가스 발사
        GameObject instantGas = Instantiate(gas, gasPosition.position, gasPosition.rotation);
        Rigidbody gasRigid = instantGas.GetComponent<Rigidbody>();
        gasRigid.velocity = gasPosition.forward * 50;
        
        yield return null;
    }
}
