using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gas : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject, 0.5f);
        /*if(collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject, 3);
        }else if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }*/
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject, 0.5f);
    }
}
