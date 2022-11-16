using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class field : MonoBehaviour
{
    // TODO 각 필드마다 주어지는 퀘스트는 처음 진입 시 Alert으로 크게 보여주고 이후부터는 우상단 체력바 밑에 표시해주기
    // 재민이가 체력바 밑에 표시하는 기능 추가해줄거임 ^^
    string questText;
    bool isQuestClear;
    GameObject alertMessageObj;
    alertMessage alertMessageScript;
    GameObject invisibleWallObject;
    invisibleWall invisibleWallScript;
    GameObject flameObj;
    fireAndSmoke flameScript;
    GameObject playerObject;
    GameObject slateObj;
    slate slateScript;
    GameObject fireExtinguisherObj;
    fireExtinguisher fireExtinguisherScript;

    void Start()
    {
        this.isQuestClear = false;
        this.invisibleWallObject = GameObject.Find("InvisibleWall0");
        this.invisibleWallScript = invisibleWallObject.GetComponent<invisibleWall>();
        this.flameObj = GameObject.Find("FlameStreamMain");
        this.flameScript = flameObj.GetComponent<fireAndSmoke>();
        this.alertMessageObj = GameObject.Find("TopAlertMessage");
        this.alertMessageScript = alertMessageObj.GetComponent<alertMessage>();
        this.playerObject = GameObject.Find("FirstPerson-AIO");
        this.slateObj = GameObject.Find("slate0");
        this.slateScript = slateObj.GetComponent<slate>();
        this.fireExtinguisherObj = GameObject.Find("FireExtinguisher0");
        this.fireExtinguisherScript = fireExtinguisherObj.GetComponent<fireExtinguisher>();
    }

    
    void Update()
    {
    }

    // ========================== Field 퀘스트 실행과 관련된 메서드 Start
    // 게임이 시작됐을 때 또는 투명벽을 넘을 때 퀘스트 시작 - 이렇게 호출을 한 번만 해야 메세지가 계속 뜨는 이슈 방지
    public void startFieldQuest()
    {
        GameObject obj = GameObject.Find("Field0");
        GameObject fieldGameObject = this.GetChildGameObject(obj);
        if (Vector3.Distance(fieldGameObject.transform.position, playerObject.transform.position) <= 25f)
        {
            this.GetFieldMethod(fieldGameObject.transform.name);
        }
    }

    // 전체 Field 중 가장 가까운 Field 찾기
    private GameObject GetChildGameObject(GameObject obj)
    {
        GameObject childObj = null;
        string gameObjectNanme = "";
        int minIndex = 0;
        float minObecjtDistance = Vector3.Distance(obj.transform.GetChild(minIndex).gameObject.transform.position, this.playerObject.transform.position);
        if (obj.transform.childCount == 1 || obj.transform.childCount == 0)
        {
            gameObjectNanme = obj.transform.GetChild(0).gameObject.name;
        }
        else
        {
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                if (Vector3.Distance(obj.transform.GetChild(i).gameObject.transform.position, this.playerObject.transform.position) < minObecjtDistance)
                {
                    minIndex = i;
                    minObecjtDistance = Vector3.Distance(obj.transform.GetChild(i).gameObject.transform.position, this.playerObject.transform.position);
                }
            }
            // gameObjectNanme = obj.transform.GetChild(minIndex).gameObject.name;
            childObj = obj.transform.GetChild(minIndex).gameObject;
        }
        return childObj;
    }

    // field이름에 해당하는 Quest Method 찾아서 실행
    private void GetFieldMethod(string fieldName)
    {
        // reflection으로 값 실행 
        Type types = typeof(field);
        MethodInfo myClassFuncCallme = types.GetMethod(fieldName,
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);

        //이제 Invoke를 하면 해당함수의 본문을 실행한다.
        myClassFuncCallme.Invoke(this, null);
    }
    // ========================== Field 퀘스트 실행과 관련된 메서드 End


    // ========================== Field 퀘스트 메서드 Start
    // 퀘스트 요청에 따른 세팅
    private void SetQuest()
    {
        // Field진입 시 Alert 띄우기
        this.alertMessageScript.setTopAlertText(this.questText);
        // Quest를 못 깬 상태로 변경
        this.isQuestClear = false;
        // 투명벽을 넘을 수 없게 blockMode로 변경
        this.invisibleWallScript.fieldStateChange();
    }

    // 화재가 난 곳에 존재하는 Slate를 열지 말지 테스트하는 Field Quest
    void ShowFirePlaceSlateManageTestField()
    {
        Debug.Log("ShowFirePlaceSlateManageTestField Start");
        this.questText = "건물 내 화재가 발생하여 방화 슬레이트가 내려갔습니다\n방화슬레이트를 열고 탈출을 시도하십시요";
        this.SetQuest();

    }

    // 화재 연기가 피어오르고 손수건에 물을 뭍혀 호흡기를 보호하는지 Test하는 Field Quest
    private void ShowSmokeAreaAndHandkerchiefUseTestField()
    {
        Debug.Log("ShowSmokeAreaAndHandkerchiefUseTestField Start");
        this.questText = "화재 연기가 올라오고 있습니다.\n올바른 행동을 취하십시요.(안주머니에 손수건이 있습니다.)";
        this.SetQuest();

    }

    // 화장실 앞을 지날 때
    private void ShowWashstandUseTestField()
    {
        Debug.Log("ShowWashstandUseTestField Start");
        this.questText = "개수대가 보입니다\n불에 그냥 접근할 경우 위험할 수 있습니다.";
        this.SetQuest();
    }

    // 슬레이트 문을 열고 실제로 다른 층으로 이동하는 것을 테스트하는 Field Quest
    private void ShowSlateUseTestField()
    {
        Debug.Log("ShowSlateUseTestField Start");
        this.questText = "탈출구를 활용해 탈출하십시요";
        this.SetQuest();
        this.flameScript.closeFireSmokeDamage();
    }

    // 소화기를 쏠 수 있는 상태로 만든는 방법을 테스트하는 Field
    private void ShowFireExtinguisherTestField()
    {
        Debug.Log("ShowFireExtinguisherTestField Start");
        this.questText = "화재를 발견하였습니다.\n화재를 진압하기 위해 소화기를 찾으십시요";
        this.SetQuest();
        this.slateScript.closeBrokenSlate();
        // TODO
        // 소화기 잡아서 들면 클리어되게 해줘(소화기 쪽에 TODO 써놨어)
        this.WaitForIt();
        this.QuestClearMethod();
    }

    // 소화기 사용으로 불을 진압하는 Field Quest
    private void ShowFireExtinguisherUseTestField()
    {
        Debug.Log("ShowFireExtinguisherUseTestField Start");
        this.questText = "화재가 발생한 지역에 도착했습니다.\n소화기로 진압하십시요";
        this.SetQuest();
        //  TODO
        // 지금은 2초있으면 그냥 퀘스트 완료인데 화재 진압 완료하면 퀘스트 완료되는 걸로 바꿔줘
        // 화재가 무슨 스크립트인지는 모르겠는데 그 스크립트에서 불 다 꺼지면 밑에 QuestClearMethod()만 한번 호출해줘
        // 호출할 때는 slate에서 내가 field 스크립트를 어떻게 불러왔는지 확인하면 돼 쉬워
        // 참고로 field랑 fieldQuiz가 달라서 생존 Scene에서는 fieldQuiz를 불러와야되고 탈출에서는 field를 불러와야해
        this.WaitForIt();
        this.QuestClearMethod();
    }

    // 화재 지역을 통과하기 위해 몸에 물을 뿌리고 화재 지역을 넘어가는 것을 Test하는 Field Quest
    private void ShowUseWaterOnMyBodyTestField()
    {
        Debug.Log("ShowUseWaterOnMyBodyTestField Start");
        this.questText = "화재가 번저 더 이상 진압할 수 없습니다.\n몸에 물을 뿌리고 화재지역을 탈출하십시요";
        this.SetQuest();
    }

    // 게임 Clear Field
    private void ShowGameClear()
    {
        Debug.Log("ShowFireExtinguisherTestField Start");
        this.questText = "Game Clear";
        this.SetQuest();
        float nowTime = Time.time;
        StartCoroutine(WaitForIt());
        Application.Quit();
    }

    // 2초간 대기
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
    }
    // ========================== Field 퀘스트 메서드 End

    // ========================== Field 퀘스트 클리어 관련 메서드 Start
    // 퀘스트 성공 시 통과
    public void QuestClearMethod()
    {
        // 투명벽을 넘을 수 있도록 triggerMode로 변경
        this.invisibleWallScript.fieldStateChange();
        // Quest를 못 깬 상태로 변경
        this.isQuestClear = true;
        this.questText = "퀘스트가 완료되었습니다.\n다음 필드로 이동해주세요";
        this.alertMessageScript.setTopAlertText(this.questText);
    }

    // ========================== Field 퀘스트 클리어 관련 메서드 End

}
