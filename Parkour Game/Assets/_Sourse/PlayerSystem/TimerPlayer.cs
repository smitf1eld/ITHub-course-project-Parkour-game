using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerPlayer : MonoBehaviour
{
    public int counter = 0;
    public TextMeshProUGUI Timerr;
    void Start()
    {
        Timerr.text = 0.ToString();
        InvokeRepeating(nameof(IncreaseCounter), 1f, 1f);
    }

    void Update()
    {
        Timerr.text = counter.ToString();
    }
    public void SetDefault()
    {
        Timerr.text = "0";
        counter = 0;
    }

    void IncreaseCounter()
    {
        counter++;
    }
}