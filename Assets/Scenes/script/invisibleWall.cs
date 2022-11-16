using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleWall : MonoBehaviour
{
    bool isInvisibleWallOpen;
    GameObject allInvisibleWall;
    GameObject fieldObject;
    field fieldScript;

    void Start()
    {
        this.allInvisibleWall = GameObject.Find("InvisibleWall0");
        this.fieldObject = GameObject.Find("Field0");
        this.fieldScript = fieldObject.GetComponent<field>();
        this.triggerMode();
    }

    void Update()
    {
    }

    private void blockMode()
    {
        for (int i = 0; i < this.allInvisibleWall.transform.childCount; i++)
        {
            this.allInvisibleWall.transform.GetChild(i).gameObject.GetComponent<MeshCollider>().isTrigger = false;
        }
        this.isInvisibleWallOpen = true;
    }

    private void triggerMode()
    {
        for (int i = 0; i < this.allInvisibleWall.transform.childCount; i++)
        {
            this.allInvisibleWall.transform.GetChild(i).gameObject.GetComponent<MeshCollider>().convex = true;
            this.allInvisibleWall.transform.GetChild(i).gameObject.GetComponent<MeshCollider>().isTrigger = true;
        }
        this.isInvisibleWallOpen = false;
    }

    // ������ ���� field�� ����ߴٴ� ���� field quest�� Ŭ�����ߴٴ� ��
    public void fieldStateChange()
    {
        if (this.isInvisibleWallOpen)
        {
            this.triggerMode();
        }else
        {
            this.blockMode();
        }
    }

    // �ٸ� Field�� ���� �� ����Ʈ ����
    private void OnTriggerExit(Collider other)
    {
        this.fieldScript.startFieldQuest();
    }
}
