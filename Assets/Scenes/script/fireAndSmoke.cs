using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAndSmoke : MonoBehaviour
{
    // ���� ������ �ο� ����
    bool isOpend;
    GameObject playerObject;
    Playered player;
    float nowTime;

    // Start is called before the first frame update
    void Start()
    {
        this.playerObject = GameObject.Find("FirstPerson-AIO");
        this.player = playerObject.GetComponent<Playered>();
        this.isOpend = false;
    }

    void Update()
    {
        this.tooCloseToFirePlace();
        this.openFirePlaceDamage();
    }

    // ȭ�� ��ȭ ������Ʈ �� ���
    void openFirePlaceDamage()
    {
        // Player�� Ctrl�� ������ ������ ������ 4�� ���� - �̷��� ü��
        float damageValue = 0.005f;
        if (this.player.GetIsPlayerSit())
        {
            damageValue = 0.001f;
        }
        else
        {
            damageValue = 0.03f;
        }
        if (this.isOpend)
        {
            this.player.TakeDamage(damageValue);
        }

    }

    public void openFireSmokeDamage()
    {
        this.isOpend = true;
    }
    public void closeFireSmokeDamage()
    {
        this.isOpend = false;
    }

    // ȭ�翡 �ٰ��� ���
    private void tooCloseToFirePlace()
    {
        GameObject slateObj = gameObject;
        if (Vector3.Distance(slateObj.transform.position, playerObject.transform.position) <= 5f)
        {
            this.player.TakeDamage(20f);
        }
        else if (Vector3.Distance(slateObj.transform.position, playerObject.transform.position) <= 3f)
        {
            this.player.TakeDamage(70f);
        }
        else if (Vector3.Distance(slateObj.transform.position, playerObject.transform.position) <= 1f)
        {
            this.player.TakeDamage(100f);
        }
    }


}
