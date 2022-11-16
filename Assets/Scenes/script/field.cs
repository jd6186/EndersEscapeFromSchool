using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using System;

public class field : MonoBehaviour
{
    // TODO �� �ʵ帶�� �־����� ����Ʈ�� ó�� ���� �� Alert���� ũ�� �����ְ� ���ĺ��ʹ� ���� ü�¹� �ؿ� ǥ�����ֱ�
    // ����̰� ü�¹� �ؿ� ǥ���ϴ� ��� �߰����ٰ��� ^^
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

    // ========================== Field ����Ʈ ����� ���õ� �޼��� Start
    // ������ ���۵��� �� �Ǵ� ������ ���� �� ����Ʈ ���� - �̷��� ȣ���� �� ���� �ؾ� �޼����� ��� �ߴ� �̽� ����
    public void startFieldQuest()
    {
        GameObject obj = GameObject.Find("Field0");
        GameObject fieldGameObject = this.GetChildGameObject(obj);
        if (Vector3.Distance(fieldGameObject.transform.position, playerObject.transform.position) <= 25f)
        {
            this.GetFieldMethod(fieldGameObject.transform.name);
        }
    }

    // ��ü Field �� ���� ����� Field ã��
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

    // field�̸��� �ش��ϴ� Quest Method ã�Ƽ� ����
    private void GetFieldMethod(string fieldName)
    {
        // reflection���� �� ���� 
        Type types = typeof(field);
        MethodInfo myClassFuncCallme = types.GetMethod(fieldName,
                BindingFlags.Instance | BindingFlags.Static |
                BindingFlags.NonPublic | BindingFlags.Public);

        //���� Invoke�� �ϸ� �ش��Լ��� ������ �����Ѵ�.
        myClassFuncCallme.Invoke(this, null);
    }
    // ========================== Field ����Ʈ ����� ���õ� �޼��� End


    // ========================== Field ����Ʈ �޼��� Start
    // ����Ʈ ��û�� ���� ����
    private void SetQuest()
    {
        // Field���� �� Alert ����
        this.alertMessageScript.setTopAlertText(this.questText);
        // Quest�� �� �� ���·� ����
        this.isQuestClear = false;
        // ������ ���� �� ���� blockMode�� ����
        this.invisibleWallScript.fieldStateChange();
    }

    // ȭ�簡 �� ���� �����ϴ� Slate�� ���� ���� �׽�Ʈ�ϴ� Field Quest
    void ShowFirePlaceSlateManageTestField()
    {
        Debug.Log("ShowFirePlaceSlateManageTestField Start");
        this.questText = "�ǹ� �� ȭ�簡 �߻��Ͽ� ��ȭ ������Ʈ�� ���������ϴ�\n��ȭ������Ʈ�� ���� Ż���� �õ��Ͻʽÿ�";
        this.SetQuest();

    }

    // ȭ�� ���Ⱑ �Ǿ������ �ռ��ǿ� ���� ���� ȣ��⸦ ��ȣ�ϴ��� Test�ϴ� Field Quest
    private void ShowSmokeAreaAndHandkerchiefUseTestField()
    {
        Debug.Log("ShowSmokeAreaAndHandkerchiefUseTestField Start");
        this.questText = "ȭ�� ���Ⱑ �ö���� �ֽ��ϴ�.\n�ùٸ� �ൿ�� ���Ͻʽÿ�.(���ָӴϿ� �ռ����� �ֽ��ϴ�.)";
        this.SetQuest();

    }

    // ȭ��� ���� ���� ��
    private void ShowWashstandUseTestField()
    {
        Debug.Log("ShowWashstandUseTestField Start");
        this.questText = "�����밡 ���Դϴ�\n�ҿ� �׳� ������ ��� ������ �� �ֽ��ϴ�.";
        this.SetQuest();
    }

    // ������Ʈ ���� ���� ������ �ٸ� ������ �̵��ϴ� ���� �׽�Ʈ�ϴ� Field Quest
    private void ShowSlateUseTestField()
    {
        Debug.Log("ShowSlateUseTestField Start");
        this.questText = "Ż�ⱸ�� Ȱ���� Ż���Ͻʽÿ�";
        this.SetQuest();
        this.flameScript.closeFireSmokeDamage();
    }

    // ��ȭ�⸦ �� �� �ִ� ���·� ����� ����� �׽�Ʈ�ϴ� Field
    private void ShowFireExtinguisherTestField()
    {
        Debug.Log("ShowFireExtinguisherTestField Start");
        this.questText = "ȭ�縦 �߰��Ͽ����ϴ�.\nȭ�縦 �����ϱ� ���� ��ȭ�⸦ ã���ʽÿ�";
        this.SetQuest();
        this.slateScript.closeBrokenSlate();
        // TODO
        // ��ȭ�� ��Ƽ� ��� Ŭ����ǰ� ����(��ȭ�� �ʿ� TODO �����)
        this.WaitForIt();
        this.QuestClearMethod();
    }

    // ��ȭ�� ������� ���� �����ϴ� Field Quest
    private void ShowFireExtinguisherUseTestField()
    {
        Debug.Log("ShowFireExtinguisherUseTestField Start");
        this.questText = "ȭ�簡 �߻��� ������ �����߽��ϴ�.\n��ȭ��� �����Ͻʽÿ�";
        this.SetQuest();
        //  TODO
        // ������ 2�������� �׳� ����Ʈ �Ϸ��ε� ȭ�� ���� �Ϸ��ϸ� ����Ʈ �Ϸ�Ǵ� �ɷ� �ٲ���
        // ȭ�簡 ���� ��ũ��Ʈ������ �𸣰ڴµ� �� ��ũ��Ʈ���� �� �� ������ �ؿ� QuestClearMethod()�� �ѹ� ȣ������
        // ȣ���� ���� slate���� ���� field ��ũ��Ʈ�� ��� �ҷ��Դ��� Ȯ���ϸ� �� ����
        // ����� field�� fieldQuiz�� �޶� ���� Scene������ fieldQuiz�� �ҷ��;ߵǰ� Ż�⿡���� field�� �ҷ��;���
        this.WaitForIt();
        this.QuestClearMethod();
    }

    // ȭ�� ������ ����ϱ� ���� ���� ���� �Ѹ��� ȭ�� ������ �Ѿ�� ���� Test�ϴ� Field Quest
    private void ShowUseWaterOnMyBodyTestField()
    {
        Debug.Log("ShowUseWaterOnMyBodyTestField Start");
        this.questText = "ȭ�簡 ���� �� �̻� ������ �� �����ϴ�.\n���� ���� �Ѹ��� ȭ�������� Ż���Ͻʽÿ�";
        this.SetQuest();
    }

    // ���� Clear Field
    private void ShowGameClear()
    {
        Debug.Log("ShowFireExtinguisherTestField Start");
        this.questText = "Game Clear";
        this.SetQuest();
        float nowTime = Time.time;
        StartCoroutine(WaitForIt());
        Application.Quit();
    }

    // 2�ʰ� ���
    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);
    }
    // ========================== Field ����Ʈ �޼��� End

    // ========================== Field ����Ʈ Ŭ���� ���� �޼��� Start
    // ����Ʈ ���� �� ���
    public void QuestClearMethod()
    {
        // ������ ���� �� �ֵ��� triggerMode�� ����
        this.invisibleWallScript.fieldStateChange();
        // Quest�� �� �� ���·� ����
        this.isQuestClear = true;
        this.questText = "����Ʈ�� �Ϸ�Ǿ����ϴ�.\n���� �ʵ�� �̵����ּ���";
        this.alertMessageScript.setTopAlertText(this.questText);
    }

    // ========================== Field ����Ʈ Ŭ���� ���� �޼��� End

}
