using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckPointSystem
{
    public class DeathCheck : MonoBehaviour
    {
        [SerializeField]
        private CoreCheckpoint coreCheckpoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Death") || other.CompareTag("Pila"))
            {
                coreCheckpoint.TeleportToLastCheckpoint();
            }
        }
    }
}