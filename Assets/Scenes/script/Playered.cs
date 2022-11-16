using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playered : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float myMaxTime = 100;
    public float currentTime;
    bool isShowered;
    bool isPlayerSit;

    public GameObject healthBarObject;
    public HealthBar healthBar;
    Canvas bodyWashGaugeCanvas;
    public GameObject timeBarObject;
    public bodyWashGauge timeSlider;
    GameObject alertMessageObj;
    alertMessage alertMessageScript;

    // Start is called before the first frame update
    void Start()
    {
        this.healthBarObject = GameObject.Find("healthSlider");
        this.healthBar = healthBarObject.GetComponent<HealthBar>();
        this.currentHealth = this.maxHealth;

        this.isShowered = false;
        this.bodyWashGaugeCanvas = GameObject.Find("bodyWashGaugeCanvas").GetComponent<Canvas>();

        this.timeBarObject = GameObject.Find("TimeSlider");
        this.timeSlider = timeBarObject.GetComponent<bodyWashGauge>();
        this.currentTime = this.myMaxTime;

        this.alertMessageObj = GameObject.Find("TopAlertMessage");
        this.alertMessageScript = alertMessageObj.GetComponent<alertMessage>();
        this.isPlayerSit = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 체력 게이지가 0이면 유저 게임 종료
        if (this.healthBar.getNowHealthValue() <= 0f)
        {
            this.alertMessageScript.setTopAlertText("Game Over");
            float timeSpan = 0;
            Application.Quit();
        }


        // Ctrl누르면 앉게 되면서 연기로 인한 데미지 절반으로 감소(GetKeyDown은 1회만 체크하기 때문에 GetKey로 변경)
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            this.isPlayerSit = true;
        } else
        {
            this.isPlayerSit = false;
        }

        // 몸에 묻은 물 시간 체크
        this.usebodyWashTime();
    }

    // 외부에서 데미지가 들어오는 것을 감지
    public void TakeDamage(float damage)
    {
        this.currentHealth -= damage;
        healthBar.SetHealth(this.currentHealth);
    }

    // 몸에 묻은 물 남은 시간 초기화(중간 중간 물 뭍히기 가능)
    public void doBodyWash()
    {
        this.isShowered = true;
        this.timeSlider.SetTime(this.myMaxTime);
        this.bodyWashGaugeCanvas.enabled = true;
    }

    // 시간이 지나 몸에 묻은 물이 마르는 것 체크
    private void bodyWashCancle()
    {
        this.isShowered = false;
        this.bodyWashGaugeCanvas.enabled = false;
    }

    // 몸에 묻은 물 타임 어택
    private void usebodyWashTime()
    {
        if (this.isShowered)
        {
            this.currentTime -= Time.deltaTime + 0.05f;
            this.timeSlider.SetTime(this.currentTime);
            if (this.currentTime <= 0f)
            {
                this.bodyWashCancle();
            }
        }
        else
        {
            this.bodyWashCancle();
        }
    }
    public bool GetIsPlayerSit()
    {
        return isPlayerSit;
    }
}
