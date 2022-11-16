using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escapeQuiz : MonoBehaviour
{
    GameObject playerObj;
    Playered playerScript;
    GameObject fieldObject;
    fieldQuiz fieldScript;
    Canvas escapeQuizFirstCanvas;
    Canvas escapeQuizSecondCanvas;
    Canvas escapeQuizThirdCanvas;
    Canvas escapeQuizFourthCanvas;
    Canvas escapeQuizFivthCanvas;
    bool isFirstTime;
    bool isOpend;
    bool isFirstClear;
    bool isSecondClear;
    bool isThirdClear;
    bool isFourthClear;
    bool isFivthClear;
    // Start is called before the first frame update
    void Start()
    {
        this.playerObj = GameObject.Find("FirstPerson-AIO");
        this.playerScript = playerObj.GetComponent<Playered>();
        this.fieldObject = GameObject.Find("Field0");
        this.fieldScript = fieldObject.GetComponent<fieldQuiz>();
        this.escapeQuizFirstCanvas = GameObject.Find("EscapeFirstQuizCanvas").GetComponent<Canvas>();
        this.escapeQuizSecondCanvas = GameObject.Find("EscapeSecondQuizCanvas").GetComponent<Canvas>();
        this.escapeQuizThirdCanvas = GameObject.Find("EscapeThirdQuizCanvas").GetComponent<Canvas>();
        this.escapeQuizFourthCanvas = GameObject.Find("EscapeFourthQuizCanvas").GetComponent<Canvas>();
        this.escapeQuizFivthCanvas = GameObject.Find("EscapeFivthQuizCanvas").GetComponent<Canvas>();
        this.escapeQuizFirstCanvas.enabled = false;
        this.escapeQuizSecondCanvas.enabled = false;
        this.escapeQuizThirdCanvas.enabled = false;
        this.escapeQuizFourthCanvas.enabled = false;
        this.escapeQuizFivthCanvas.enabled = false;
        this.isFirstTime = true;
        this.isOpend = false;
        this.isFirstClear = false;
        this.isSecondClear = false;
        this.isThirdClear = false;
        this.isFourthClear = false;
        this.isFivthClear = false;
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
                this.escapeQuizFirstCanvas.enabled = true;
            }
            else if (!this.isSecondClear)
            {
                this.escapeQuizFirstCanvas.enabled = false;
                this.escapeQuizSecondCanvas.enabled = true;
            }
            else if (!this.isThirdClear)
            {
                this.escapeQuizSecondCanvas.enabled = false;
                this.escapeQuizThirdCanvas.enabled = true;
            }
            else if (!this.isFourthClear)
            {
                this.escapeQuizThirdCanvas.enabled = false;
                this.escapeQuizFourthCanvas.enabled = true;
            }
            else if (!this.isFivthClear)
            {
                this.escapeQuizFourthCanvas.enabled = false;
                this.escapeQuizFivthCanvas.enabled = true;
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
    }
    public void fivthQuizClear()
    {
        this.isFivthClear = true;
        this.isFirstTime = false;
        this.fieldScript.QuestClearMethod();
        this.isOpend = false;
        this.escapeQuizFivthCanvas.enabled = false;
    }
    public void selectWrongAnswer()
    {
        this.playerScript.TakeDamage(10);
    }
    public void escapeQuizCanvasOpen()
    {
        this.isOpend = true;
    }
}
