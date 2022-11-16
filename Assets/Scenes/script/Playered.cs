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
        // ü�� �������� 0�̸� ���� ���� ����
        if (this.healthBar.getNowHealthValue() <= 0f)
        {
            this.alertMessageScript.setTopAlertText("Game Over");
            float timeSpan = 0;
            Application.Quit();
        }


        // Ctrl������ �ɰ� �Ǹ鼭 ����� ���� ������ �������� ����(GetKeyDown�� 1ȸ�� üũ�ϱ� ������ GetKey�� ����)
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            this.isPlayerSit = true;
        } else
        {
            this.isPlayerSit = false;
        }

        // ���� ���� �� �ð� üũ
        this.usebodyWashTime();
    }

    // �ܺο��� �������� ������ ���� ����
    public void TakeDamage(float damage)
    {
        this.currentHealth -= damage;
        healthBar.SetHealth(this.currentHealth);
    }

    // ���� ���� �� ���� �ð� �ʱ�ȭ(�߰� �߰� �� ������ ����)
    public void doBodyWash()
    {
        this.isShowered = true;
        this.timeSlider.SetTime(this.myMaxTime);
        this.bodyWashGaugeCanvas.enabled = true;
    }

    // �ð��� ���� ���� ���� ���� ������ �� üũ
    private void bodyWashCancle()
    {
        this.isShowered = false;
        this.bodyWashGaugeCanvas.enabled = false;
    }

    // ���� ���� �� Ÿ�� ����
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
