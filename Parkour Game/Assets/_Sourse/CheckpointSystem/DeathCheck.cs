using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour
{
    [SerializeField]
    PlayerInputCP player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Death") || other.CompareTag("Pila"))
        {
            player.Die();
        }
    }
}
