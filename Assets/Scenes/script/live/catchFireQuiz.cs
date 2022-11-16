using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catchFireQuiz : MonoBehaviour
{
    GameObject playerObj;
    Playered playerScript;
    GameObject fieldObject;
    fieldQuiz fieldScript;
    Canvas catchFireQuizFirstCanvas;
    Canvas catchFireQuizSecondCanvas;
    Canvas catchFireQuizThirdCanvas;
    Canvas catchFireQuizFourthCanvas;
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
        this.catchFireQuizFirstCanvas = GameObject.Find("CatchFireFirstQuizCanvas").GetComponent<Canvas>();
        this.catchFireQuizSecondCanvas = GameObject.Find("CatchFireSecondQuizCanvas").GetComponent<Canvas>();
        this.catchFireQuizThirdCanvas = GameObject.Find("CatchFireThirdQuizCanvas").GetComponent<Canvas>();
        this.catchFireQuizFourthCanvas = GameObject.Find("CatchFireFourthQuizCanvas").GetComponent<Canvas>();
        this.catchFireQuizFirstCanvas.enabled = false;
        this.catchFireQuizSecondCanvas.enabled = false;
        this.catchFireQuizThirdCanvas.enabled = false;
        this.catchFireQuizFourthCanvas.enabled = false;
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
                this.catchFireQuizFirstCanvas.enabled = true;
            }
            else if (!this.isSecondClear)
            {
                this.catchFireQuizFirstCanvas.enabled = false;
                this.catchFireQuizSecondCanvas.enabled = true;
            }
            else if (!this.isThirdClear)
            {
                this.catchFireQuizSecondCanvas.enabled = false;
                this.catchFireQuizThirdCanvas.enabled = true;
            }
            else if (!this.isFourthClear)
            {
                this.catchFireQuizThirdCanvas.enabled = false;
                this.catchFireQuizFourthCanvas.enabled = true;
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
        this.isOpend = false;
        this.catchFireQuizFourthCanvas.enabled = false;
        this.fieldScript.QuestClearMethod();
    }
    public void selectWrongAnswer()
    {
        this.playerScript.TakeDamage(10);
    }
    public void catchFireQuizCanvasOpen()
    {
        this.isOpend = true;
    }
}