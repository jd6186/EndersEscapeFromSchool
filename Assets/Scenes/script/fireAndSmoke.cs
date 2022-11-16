using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireAndSmoke : MonoBehaviour
{
    // 지속 데미지 부여 여부
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

    // 화재 방화 슬레이트 연 경우
    void openFirePlaceDamage()
    {
        // Player가 Ctrl을 누르고 있으면 데미지 4배 감소 - 이래야 체감
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

    // 화재에 다가간 경우
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
