using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputCP : MonoBehaviour
{
    public TimerPlayer timerPlayer;
    [SerializeField]
    private CoreCheckpoint Core;

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
            timerPlayer.counter += 10;
        }
    }

    public void Die()
    {
        Core.TeleportToLastCheckpoint();
    }
}
