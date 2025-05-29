using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerRespawn : MonoBehaviour
{
    private CharacterController characterController;
    
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    
    // В PlayerRespawn.cs
    public void Respawn(Vector3 spawnPosition)
    {
        // Сбрасываем скорость перед телепортацией
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    
        characterController.enabled = false;
        transform.position = spawnPosition;
        characterController.enabled = true;
    
        // Добавляем небольшой "толчок" вниз для стабилизации
        if (rb != null)
        {
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
    }
}