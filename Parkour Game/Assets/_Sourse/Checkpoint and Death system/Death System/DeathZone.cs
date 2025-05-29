using UnityEngine;
using System;

public class DeathZone : MonoBehaviour
{
    public event Action OnPlayerFell;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerFell?.Invoke();
        }
    }
}