using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject[] items;
    public bool[] hasItems;

    bool iDown;
    bool sDown1;
    bool fDown;
    bool isFireReady = true;

    //체력 게이지
    public HealthBar healthBar;
    public int maxHealth = 100;
    public float currentHealth;

    GameObject nearObject;
    GameObject dangerObject;

    Item equipItem;
    int equipItemIndex = -1;

    float fireDelay;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }
    void Update()
    {
        GetInput();
        Swap();
        Interation();
        Attack();
        TakeDamage();
    }

    void GetInput()
    {
        iDown = Input.GetButtonDown("Interation");
        sDown1 = Input.GetButtonDown("Swap1");
        fDown = Input.GetButton("Fire1");
    }

    
    void Swap()
    {
        if (sDown1 && (!hasItems[0] || equipItemIndex == 0)) return;

        int itemIndex = -1;
        if (sDown1) itemIndex = 0;

        if(sDown1)
        {
            if(equipItem != null)
                equipItem.gameObject.SetActive(false);

            equipItemIndex = itemIndex;
            equipItem = items[itemIndex].GetComponent<Item>();
            equipItem.gameObject.SetActive(true);
        }
    }

    void Interation()
    {
        if(iDown && nearObject != null)
        {
            if(nearObject.tag == "Item")
            {
                SetItem itemSet = nearObject.GetComponent<SetItem>();
                int itemIndex = itemSet.value;
                hasItems[itemIndex] = true;

                Destroy(nearObject);
            }
        }
    }

    void TakeDamage()
    {
        if (dangerObject != null)
        {
            if (dangerObject.tag == "Fire")
            {
                currentHealth -= 0.3f;
                healthBar.SetHealth(currentHealth);
            }
        }

    }

    void Attack()
    {
        if (equipItem == null) return;

        fireDelay += Time.deltaTime;
        isFireReady = equipItem.rate < fireDelay;

        if (fDown && isFireReady)
        {
            equipItem.Use();
            fireDelay = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Item")
            nearObject = other.gameObject;
        if (other.tag == "Fire")
            dangerObject = other.gameObject;

    }       

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
            nearObject = null;
        if (other.tag == "Fire")
            dangerObject = null;

    }
}
