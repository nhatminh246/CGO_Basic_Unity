using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountTime : MonoBehaviour
{
    [SerializeField] private float maxTime = 5.2f;
    public static float currentTime;
    private Image Clock; 

    private void Start()
    {
        Clock = GetComponent<Image>();
        currentTime = maxTime;
    }

    private void Update()
    {
        TMP_Text timeText = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        currentTime -= Time.deltaTime;
        float fillAmount = Mathf.Clamp01(currentTime / maxTime);
        //thay doi gia tri dong ho
        Clock.fillAmount = fillAmount;
        timeText.text = ""+ (int)currentTime;

        if (currentTime <= 0)
        {
            timeText.enabled = false;
        }
    }

    public static void ResetTime()
    {
        currentTime = 5.2f;
    }
}