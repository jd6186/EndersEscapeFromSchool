using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handkerchief : MonoBehaviour
{
    // Start is called before the first frame update
    bool isUsed;
    float useCount;
    float maxTime = 30f;
    GameObject playerObject;
    Playered player;
    Canvas handkerchiefCanvas;
    GameObject fireAndSmokeObject;
    fireAndSmoke fireAndSmokeScript;

    void Start()
    {
        this.isUsed = false;
        this.useCount = 0;
        this.playerObject = GameObject.Find("FirstPerson-AIO");
        this.player = playerObject.GetComponent<Playered>();
        this.fireAndSmokeObject = GameObject.Find("FlameStreamMain");
        this.fireAndSmokeScript = fireAndSmokeObject.GetComponent<fireAndSmoke>();
        this.handkerchiefCanvas = GameObject.Find("handkerchiefCanvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        this.useHandkerchiefTime();
    }

    // �ռ����� ���� �԰� �ڸ� ���� ��� ��� �ð� �ʱ�ȭ(�߰� �߰� �� ������ ����)
    public void useHandkerchief()
    {
        this.isUsed = true;
        this.useCount = 0;
        this.handkerchiefCanvas.enabled = true;
    }

    // �ð��� ���� �ռ����� ��� ���ϰ� �Ǵ� �ܿ�
    private void unUsedHandkerchief()
    {
        this.isUsed = false;
        this.handkerchiefCanvas.enabled = false;
    }

    // �ռ��� Ÿ�� ����
    private void useHandkerchiefTime()
    {
        // �ռ����� �̿��� �ڿ� ���� ���� ���¿����� ȭ�� ���� ����� X
        if (this.isUsed)
        {
            this.useCount += Time.deltaTime;
            this.fireAndSmokeScript.closeFireSmokeDamage();

            if (this.useCount > this.maxTime)
            {
                this.unUsedHandkerchief();
                // this.fireAndSmokeScript.openFireSmokeDamage();
            }
        } else
        {
            this.unUsedHandkerchief();
        }
    }
}
