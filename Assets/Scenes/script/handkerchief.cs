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

    // 손수건을 적셔 입과 코를 막는 경우 사용 시간 초기화(중간 중간 물 뭍히기 가능)
    public void useHandkerchief()
    {
        this.isUsed = true;
        this.useCount = 0;
        this.handkerchiefCanvas.enabled = true;
    }

    // 시간이 지나 손수건을 사용 못하게 되는 겨우
    private void unUsedHandkerchief()
    {
        this.isUsed = false;
        this.handkerchiefCanvas.enabled = false;
    }

    // 손수건 타임 어택
    private void useHandkerchiefTime()
    {
        // 손수건을 이용해 코와 입을 막은 상태에서는 화재 연기 대미지 X
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
