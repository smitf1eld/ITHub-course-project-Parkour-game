using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputCP : MonoBehaviour
{
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
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Core.ReturnToLastCheckpoint();
        }
    }

    public void Die()
    {
        Core.ReturnToLastCheckpoint();
    }
}
