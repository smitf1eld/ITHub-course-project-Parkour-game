using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using CheckPointSystem;

namespace CheckPointSystem
{
    public class PlayerInputCP : MonoBehaviour
    {
        [SerializeField]
        private CoreCheckpoint Core;
        private TimerPlayer _timerPlayer;

        private void Start()
        {
            if (!Core)
            {
                Core = FindObjectOfType<CoreCheckpoint>();
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Core.SetCheckpoint();
                if (CoreCheckpoint.CounterCP > 0)
                {
                    CoreCheckpoint.CounterCP -= 1;
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Core.TeleportToLastCheckpoint();
                _timerPlayer.isRespaunPlayer();
            }
        }

        public void Die()
        {
            Core.TeleportToLastCheckpoint();
        }
    }

}