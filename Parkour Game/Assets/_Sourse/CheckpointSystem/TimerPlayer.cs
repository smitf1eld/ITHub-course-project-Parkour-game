using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class TimerPlayer : MonoBehaviour
{
    public int counter = 0;
    public TextMeshProUGUI Timerr;
    [SerializeField]
    private GameObject toggleObject;
    void Start()
    {
        Timerr.text = 0.ToString();
        InvokeRepeating(nameof(IncreaseCounter), 1f, 1f);
    }
    void Update()
    {
        Timerr.text = counter.ToString();
        if (Input.GetKeyDown(KeyCode.R))
        {
            toggleObject.SetActive(true);
            StartCoroutine(TurnOffAfterDelay());
            counter += 10;
        }

    }
    private IEnumerator TurnOffAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        toggleObject.SetActive(false);
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