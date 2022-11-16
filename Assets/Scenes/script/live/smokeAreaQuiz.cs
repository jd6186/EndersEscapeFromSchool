using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class smokeAreaQuiz : MonoBehaviour
{
    GameObject playerObj;
    Playered playerScript;
    GameObject fieldObject;
    fieldQuiz fieldScript;
    Canvas smokeAreaQuizFirstCanvas;
    Canvas smokeAreaQuizSecondCanvas;
    Canvas smokeAreaQuizThirdCanvas;
    Canvas smokeAreaQuizFourthCanvas;
    bool isFirstTime;
    bool isOpend;
    bool isFirstClear;
    bool isSecondClear;
    bool isThirdClear;
    bool isFourthClear;
    // Start is called before the first frame update
    void Start()
    {
        this.playerObj = GameObject.Find("FirstPerson-AIO");
        this.playerScript = playerObj.GetComponent<Playered>();
        this.fieldObject = GameObject.Find("Field0");
        this.fieldScript = fieldObject.GetComponent<fieldQuiz>();
        this.smokeAreaQuizFirstCanvas = GameObject.Find("SmokeAreaFirstQuizCanvas").GetComponent<Canvas>();
        this.smokeAreaQuizSecondCanvas = GameObject.Find("SmokeAreaSecondQuizCanvas").GetComponent<Canvas>();
        this.smokeAreaQuizThirdCanvas = GameObject.Find("SmokeAreaThirdQuizCanvas").GetComponent<Canvas>();
        this.smokeAreaQuizFourthCanvas = GameObject.Find("SmokeAreaFourthQuizCanvas").GetComponent<Canvas>();
        this.smokeAreaQuizFirstCanvas.enabled = false;
        this.smokeAreaQuizSecondCanvas.enabled = false;
        this.smokeAreaQuizThirdCanvas.enabled = false;
        this.smokeAreaQuizFourthCanvas.enabled = false;
        this.isFirstTime = true;
        this.isOpend = false;
        this.isFirstClear = false;
        this.isSecondClear = false;
        this.isThirdClear = false;
        this.isFourthClear = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isOpend)
        {
            this.openQuizCanvas();
        }
    }

    private void openQuizCanvas()
    {
        if (this.isFirstTime)
        {
            if (!this.isFirstClear)
            {
                this.smokeAreaQuizFirstCanvas.enabled = true;
            }
            else if (!this.isSecondClear)
            {
                this.smokeAreaQuizFirstCanvas.enabled = false;
                this.smokeAreaQuizSecondCanvas.enabled = true;
            }
            else if (!this.isThirdClear)
            {
                this.smokeAreaQuizSecondCanvas.enabled = false;
                this.smokeAreaQuizThirdCanvas.enabled = true;
            }
            else if (!this.isFourthClear)
            {
                this.smokeAreaQuizThirdCanvas.enabled = false;
                this.smokeAreaQuizFourthCanvas.enabled = true;
            }
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
        this.isFourthClear = true;
        this.isFirstTime = false;
        this.fieldScript.QuestClearMethod();
        this.isOpend = false;
        this.smokeAreaQuizFourthCanvas.enabled = false;
    }
    public void selectWrongAnswer()
    {
        this.playerScript.TakeDamage(10);
    }
    public void smokeAreaQuizCanvasOpen()
    {
        this.isOpend = true;
    }
}
