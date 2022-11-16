using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireExtinguisherQuiz : MonoBehaviour
{
    GameObject playerObj;
    Playered playerScript;
    Canvas fireExtinguisherTestFirstCanvas;
    Canvas fireExtinguisherTestSecondCanvas;
    Canvas fireExtinguisherTestThirdCanvas;
    Canvas fireExtinguisherTestFourthCanvas;
    Canvas useFireExtinguisherCanvas;
    GameObject nowfireExtinguisher;
    GameObject fieldObject;
    fieldQuiz fieldScript;
    bool isFirstTime;
    bool isFirstClear;
    bool isSecondClear;
    bool isThirdClear;
    bool isFourthClear;
    bool isShowFireExtinguisherUseTestField;
    // Start is called before the first frame update
    void Start()
    {
        this.fieldObject = GameObject.Find("Field0");
        this.fieldScript = fieldObject.GetComponent<fieldQuiz>();
        this.playerObj = GameObject.Find("FirstPerson-AIO");
        this.playerScript = playerObj.GetComponent<Playered>();
        this.useFireExtinguisherCanvas = GameObject.Find("UseFireExtinguisherCanvas").GetComponent<Canvas>();
        this.fireExtinguisherTestFirstCanvas = GameObject.Find("FireExtinguisherTestFirstCanvas").GetComponent<Canvas>();
        this.fireExtinguisherTestSecondCanvas = GameObject.Find("FireExtinguisherTestSecondCanvas").GetComponent<Canvas>();
        this.fireExtinguisherTestThirdCanvas = GameObject.Find("FireExtinguisherTestThirdCanvas").GetComponent<Canvas>();
        this.fireExtinguisherTestFourthCanvas = GameObject.Find("FireExtinguisherTestFourthCanvas").GetComponent<Canvas>();
        this.useFireExtinguisherCanvas.enabled = false;
        this.fireExtinguisherTestFirstCanvas.enabled = false;
        this.fireExtinguisherTestSecondCanvas.enabled = false;
        this.fireExtinguisherTestThirdCanvas.enabled = false;
        this.fireExtinguisherTestFourthCanvas.enabled = false;
        this.isFirstTime = true;
        this.isFirstClear = false;
        this.isSecondClear = false;
        this.isThirdClear = false;
        this.isFourthClear = false;
        this.isShowFireExtinguisherUseTestField = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("FireExtinguisher0");
        string fireExtinguisherName = this.getObjectName(obj);
        GameObject fireExtinguisherObj = obj.transform.Find(fireExtinguisherName).gameObject;
        if (Vector3.Distance(fireExtinguisherObj.transform.position, this.playerObj.transform.position) <= 2f)
        {
            Debug.Log("소화기 최초 발견");
            this.nowfireExtinguisher = fireExtinguisherObj;
            this.openQuizCanvas();
        }
        if (this.nowfireExtinguisher != null)
        {
            this.canvasClose();
        }
    }
    private string getObjectName(GameObject obj)
    {
        string gameObjectNanme = "";
        int minIndex = 0;
        float minObecjtDistance = Vector3.Distance(obj.transform.GetChild(minIndex).gameObject.transform.position, this.playerObj.transform.position);
        if (obj.transform.childCount == 1 || obj.transform.childCount == 0)
        {
            gameObjectNanme = obj.transform.GetChild(0).gameObject.name;
        }
        else
        {
            for (int i = 0; i < obj.transform.childCount; i++)
            {
                if (Vector3.Distance(obj.transform.GetChild(i).gameObject.transform.position, this.playerObj.transform.position) < minObecjtDistance)
                {
                    minIndex = i;
                    minObecjtDistance = Vector3.Distance(obj.transform.GetChild(i).gameObject.transform.position, this.playerObj.transform.position);
                }
            }
            gameObjectNanme = obj.transform.GetChild(minIndex).gameObject.name;
        }
        return gameObjectNanme;
    }

    private void openQuizCanvas()
    {
        if (this.isFirstTime)
        {
            if (!this.isFirstClear && this.isShowFireExtinguisherUseTestField)
            {
                this.fireExtinguisherTestFirstCanvas.enabled = true;
            }
            else if (!this.isSecondClear)
            {
                this.fireExtinguisherTestFirstCanvas.enabled = false;
                this.fireExtinguisherTestSecondCanvas.enabled = true;
            }
            else if (!this.isThirdClear)
            {
                this.fireExtinguisherTestSecondCanvas.enabled = false;
                this.fireExtinguisherTestThirdCanvas.enabled = true;
            }
            else if (!this.isFourthClear)
            {
                this.fireExtinguisherTestThirdCanvas.enabled = false;
                this.fireExtinguisherTestFourthCanvas.enabled = true;
            }
        }
        else
        {
            this.useFireExtinguisherCanvas.enabled = true;
        }
    }

    void canvasClose()
    {
        if (Vector3.Distance(this.nowfireExtinguisher.transform.position, this.playerObj.transform.position) > 2f)
        {
            this.useFireExtinguisherCanvas.enabled = false;
            this.fireExtinguisherTestFirstCanvas.enabled = false;
            this.fireExtinguisherTestSecondCanvas.enabled = false;
            this.fireExtinguisherTestThirdCanvas.enabled = false;
            this.fireExtinguisherTestFourthCanvas.enabled = false;
            this.nowfireExtinguisher = null;
        }
    }


    public void firstQuizClear()
    {
        this.isFirstClear = true;
    }
    public void secondQuizClear()
    {
        this.isSecondClear = true;
    }
    public void thirdQuizClear()
    {
        this.isThirdClear = true;
    }
    public void fourthQuizClear()
    {
        this.fireExtinguisherTestFirstCanvas.enabled = false;
        this.fireExtinguisherTestSecondCanvas.enabled = false;
        this.fireExtinguisherTestThirdCanvas.enabled = false;
        this.fireExtinguisherTestFourthCanvas.enabled = false;
        this.isFourthClear = true;
        this.isFirstTime = false;
        this.fieldScript.QuestClearMethod();
    }
    public void selectWrongAnswer()
    {
        this.playerScript.TakeDamage(10);
    }
    public void IsShowFireExtinguisherUseTestFieldTrue()
    {
        this.isShowFireExtinguisherUseTestField = true;
    }
    public void IsShowFireExtinguisherUseTestFieldFalse()
    {
        this.isShowFireExtinguisherUseTestField = false;
    }

    // TODO
    // 유저가 소화기 드는 메서드가 뭔지 모르겠어 캔버스에 있는 버튼에서 사용 누르면 뽑아진 소화기 들게 해줘
    // 그리고 소화기 들면 QuestClearMethod()만 한번 호출해줘 -> 내가 위에서 this.fieldScript로 스크립트는 가져왔어 this.fieldScript.QuestClearMethod(); 라고 적기만 하면 돼
}
