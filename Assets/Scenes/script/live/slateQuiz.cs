using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slateQuiz : MonoBehaviour {
    float startedTime = 0;
    bool isFireSlateOpend;
    MeshRenderer slateMesh;
    GameObject playerObject;
    Playered player;
    Canvas slateIsOpen;
    Canvas fireSlateIsOpen;
    GameObject alertMessage;
    alertMessage alertMessageScript;
    GameObject nowSlate;
    GameObject fireAndSmokeObject;
    fireAndSmoke fireAndSmokeScript;
    GameObject fieldObject;
    fieldQuiz fieldScript;
    string fireSlateOpenMessage;

    void Start()
    {
        this.fieldObject = GameObject.Find("Field0");
        this.fieldScript = fieldObject.GetComponent<fieldQuiz>();
        this.slateMesh = GetComponent<MeshRenderer>();
        this.slateMesh.enabled = false;
        this.playerObject = GameObject.Find("FirstPerson-AIO");
        this.player = playerObject.GetComponent<Playered>();
        this.slateIsOpen = GameObject.Find("SlateIsOpen").GetComponent<Canvas>();
        this.slateIsOpen.enabled = false;
        this.fireSlateIsOpen = GameObject.Find("FireSlateIsOpen").GetComponent<Canvas>();
        this.fireSlateIsOpen.enabled = false;
        this.isFireSlateOpend = false;
        this.fireAndSmokeObject = GameObject.Find("FlameStreamMain");
        this.fireAndSmokeScript = fireAndSmokeObject.GetComponent<fireAndSmoke>();
        this.alertMessage = GameObject.Find("TopAlertMessage");
        this.alertMessageScript = alertMessage.GetComponent<alertMessage>();
        this.fireSlateOpenMessage = "화재 연기를 흡입하였습니다. \n체력이 지속적으로 감소하기 시작합니다.\n(체력감소를 줄이기 위해선 Ctrl 키를 눌러 앉아 주세요)";
    }

    void Update()
    {

        if (this.startedTime < 12f)
        {
            this.TimeCheck();
        }

        GameObject obj = GameObject.Find("slate0");
        string slateGameObjectNanme = this.getObjectName(obj);
        GameObject slateObj = GameObject.Find("slate0").transform.Find(slateGameObjectNanme).gameObject;

        if (this.alertMessageScript.getisAlertOpenState() == false)
        {
            this.CanvasOpenManage(slateObj);
        }
    }

    private void CanvasOpenManage(GameObject slateObj)
    {
        if (Vector3.Distance(slateObj.transform.position, playerObject.transform.position) <= 2f)
        {
            this.nowSlate = slateObj;
            if (this.nowSlate.tag.Equals("FireSlate"))
            {
                this.fireCanvasOpen();
            }
            else
            {
                this.canvasOpen();
            }
        }
        if (this.nowSlate != null)
        {
            if (this.nowSlate.tag.Equals("FireSlate"))
            {
                this.fireCanvasClose();
            }
            else
            {
                this.canvasClose();
            }
        }
    }

    private void TimeCheck()
    {
        if (this.startedTime > 10f)
        {
            this.slateMesh.enabled = true;
            return;
        }
        this.startedTime += Time.deltaTime;
    }

    public void slateOpen()
    {
        GameObject obj = GameObject.Find("slate0");
        string slateGameObjectNanme = this.getObjectName(obj);
        this.nowSlate = GameObject.Find("slate0").transform.Find(slateGameObjectNanme).gameObject;

        string nowSlateName = this.nowSlate.transform.name;
        if (nowSlateName.Equals("slate02") || nowSlateName.Equals("slate03") || nowSlateName.Equals("slate05"))
        {
            // 고장난 문은 안 열림
            this.alertMessageScript.setBottomAlertText("슬레이트가 고장나 열리지 않습니다.");
            return;
        }

        if (this.nowSlate.tag.Equals("FireSlate") && this.isFireSlateOpend == false)
        {
            this.player.TakeDamage(50f);
            this.fireAndSmokeScript.openFireSmokeDamage();
            this.isFireSlateOpend = true;
            this.alertMessageScript.setBottomAlertText(this.fireSlateOpenMessage);
        }
        // 퀘스트 클리어 조건이 걸린 슬레이트일 경우 퀘스트 클리어 조건을 달성했다고 Field에 알리기
        if (nowSlateName.Equals("slate01") || nowSlateName.Equals("slate02"))
        {
            this.fieldScript.QuestClearMethod();
        }
        this.nowSlate.SetActive(false);
    }

    public void slateClose()
    {
        GameObject obj = GameObject.Find("slate0");
        string slateGameObjectNanme = this.getObjectName(obj);
        GameObject.Find("slate0").transform.Find(slateGameObjectNanme).gameObject.SetActive(true);
        if (slateGameObjectNanme.Equals("slate01") || slateGameObjectNanme.Equals("slate02"))
        {
            this.fieldScript.QuestClearMethod();
        }
    }
    private string getObjectName(GameObject obj)
    {
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
            gameObjectNanme = obj.transform.GetChild(minIndex).gameObject.name;
        }
        return gameObjectNanme;
    }

    void canvasOpen()
    {
        this.slateIsOpen.enabled = true;
    }
    void canvasClose()
    {
        if (Vector3.Distance(this.nowSlate.transform.position, this.playerObject.transform.position) > 2f)
        {
            this.slateIsOpen.enabled = false;
            this.nowSlate = null;
        }
    }

    void fireCanvasOpen()
    {
        this.fireSlateIsOpen.enabled = true;
    }

    void fireCanvasClose()
    {
        if (Vector3.Distance(this.nowSlate.transform.position, this.playerObject.transform.position) > 2f)
        {
            this.fireSlateIsOpen.enabled = false;
            this.nowSlate = null;
        }
    }

    public void closeBrokenSlate()
    {
        GameObject obj = GameObject.Find("slate0");
        string brokenGameObjectNanme;
        int minIndex = 0;
        float minObecjtDistance = Vector3.Distance(obj.transform.GetChild(minIndex).gameObject.transform.position, this.playerObject.transform.position);
        for (int i = 0; i < obj.transform.childCount; i++)
        {
            brokenGameObjectNanme = obj.transform.GetChild(minIndex).gameObject.name;
            if (brokenGameObjectNanme.Equals("slate05"))
            {
                obj.transform.GetChild(minIndex).gameObject.SetActive(true);
                break;
            }
        }
    }
}