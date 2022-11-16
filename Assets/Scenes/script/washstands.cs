using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class washstands : MonoBehaviour
{
    GameObject playerObject;
    Playered player;
    Canvas washstandsIsOpen;
    GameObject nowWashstands;
    GameObject fieldObject;
    field fieldScript;

    public GameObject handkerchiefObj;
    public handkerchief handkerchiefScript;
    // Start is called before the first frame update
    void Start()
    {
        this.playerObject = GameObject.Find("FirstPerson-AIO");
        this.player = playerObject.GetComponent<Playered>();
        this.washstandsIsOpen = GameObject.Find("WashstandsIsOpen").GetComponent<Canvas>();
        this.washstandsIsOpen.enabled = false;
        this.handkerchiefObj = GameObject.Find("handkerchiefCanvasImg");
        this.handkerchiefScript = handkerchiefObj.GetComponent<handkerchief>();
        this.fieldObject = GameObject.Find("Field0");
        this.fieldScript = fieldObject.GetComponent<field>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("washstands0");
        string washstandsGameObjectNanme = this.getObjectName(obj);
        GameObject washstandsObj = GameObject.Find("washstands0").transform.Find(washstandsGameObjectNanme).gameObject;
        if (Vector3.Distance(washstandsObj.transform.position, playerObject.transform.position) <= 2f)
        {
            this.nowWashstands = washstandsObj;
            this.canvasOpen();
        }
        if (this.nowWashstands != null)
        {
            this.canvasClose();
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
        this.washstandsIsOpen.enabled = true;
    }
    void canvasClose()
    {
        if (Vector3.Distance(this.nowWashstands.transform.position, this.playerObject.transform.position) > 2f)
        {
            this.washstandsIsOpen.enabled = false;
            this.nowWashstands = null;
        }
    }
    public void handkerchiefOpen()
    {
        this.handkerchiefScript.useHandkerchief();
        if (this.nowWashstands.transform.name.Equals("washstands01"))
        {
            this.fieldScript.QuestClearMethod();
        }
    }
    public void bodyWashButton()
    {
        this.player.doBodyWash();
        if (this.nowWashstands.transform.name.Equals("washstands04"))
        {
            this.fieldScript.QuestClearMethod();
        }
    }
}
