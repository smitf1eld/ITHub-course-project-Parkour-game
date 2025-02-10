using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using CheckPointSystem;

namespace CheckPointSystem
{
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
        }
        private IEnumerator TurnOffAfterDelay()
        {
            yield return new WaitForSeconds(2f);
            toggleObject.SetActive(false);
        }
        public void isRespaunPlayer()
        {
            toggleObject.SetActive(true);
            StartCoroutine(TurnOffAfterDelay());
            counter += 10;
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
}