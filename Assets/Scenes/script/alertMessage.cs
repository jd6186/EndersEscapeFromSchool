using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class alertMessage : MonoBehaviour
{
    Canvas topAlertCanvas;
    bool isTopAlertOpen;
    Canvas bottomAlertCanvas;
    bool isBottomAlertOpen;
    float currentTime;
    GameObject allSelectObejct;
    // Start is called before the first frame update
    void Start()
    {
        this.topAlertCanvas = gameObject.GetComponent<Canvas>();
        this.topAlertCanvas.enabled = false;
        this.isTopAlertOpen = false;
        this.bottomAlertCanvas = GameObject.Find("BottomAlertCanvas").GetComponent<Canvas>();
        this.bottomAlertCanvas.enabled = false;
        this.isBottomAlertOpen = false;
        this.allSelectObejct = GameObject.Find("AllSelectCanvas");
    }

    void Update()
    {
        this.TopAlertCheck();
        this.BottomAlertCheck();
    }

    private void TopAlertCheck()
    {
        if (this.isTopAlertOpen)
        {
            // Alert이 떠있으면 다른 선택지는 아예 못나오게 설정
            for (int i = 0; i < this.allSelectObejct.transform.childCount; i++)
            {
                Canvas nowCanvas = this.allSelectObejct.transform.GetChild(i).gameObject.GetComponent<Canvas>();
                nowCanvas.enabled = false;
            }

            // Alert은 5초간만 유지
            this.topAlertCanvas.enabled = true;
            this.currentTime -= Time.deltaTime;
            if (this.currentTime <= 0)
            {
                this.isTopAlertOpen = false;
                this.topAlertCanvas.enabled = false;
            }
        }
    }

    private void BottomAlertCheck()
    {
        if (this.isBottomAlertOpen)
        {
            // Alert이 떠있으면 다른 선택지는 아예 못나오게 설정
            for (int i = 0; i < this.allSelectObejct.transform.childCount; i++)
            {
                Canvas nowCanvas = this.allSelectObejct.transform.GetChild(i).gameObject.GetComponent<Canvas>();
                nowCanvas.enabled = false;
            }

            // Alert은 5초간만 유지
            this.bottomAlertCanvas.enabled = true;
            this.currentTime -= Time.deltaTime;
            if (this.currentTime <= 0)
            {
                this.isBottomAlertOpen = false;
                this.bottomAlertCanvas.enabled = false;
            }
        }
    }

    public void setTopAlertText(string alertMessage)
    {
        if (!this.isTopAlertOpen)
        {
            this.currentTime = 3;
            Text alertMessageArea = this.topAlertCanvas.GetComponentInChildren<Text>();
            alertMessageArea.text = alertMessage;
            this.isTopAlertOpen = true;
        }
    }

    public void setBottomAlertText(string alertMessage)
    {
        if (!this.isBottomAlertOpen)
        {
            Debug.Log("alertMessage");
            this.currentTime = 3;
            Text alertMessageArea = this.bottomAlertCanvas.GetComponentInChildren<Text>();
            alertMessageArea.text = alertMessage;
            this.isBottomAlertOpen = true;
        }
    }

    public bool getisAlertOpenState()
    {
        return this.isBottomAlertOpen;
    }
}
