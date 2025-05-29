using UnityEngine;

public class InteractableItem : MonoBehaviour
{
    [SerializeField] private PhoneCallData phoneCallData;
    [SerializeField] private KeyCode interactionKey = KeyCode.E;
    [SerializeField] private Collider[] collidersToDisable;
    
    private bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(interactionKey))
        {
            Interact();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void Interact()
    {
        // Отключаем указанные коллайдеры
        foreach (var collider in collidersToDisable)
        {
            if (collider != null)
                collider.enabled = false;
        }

        // Запускаем телефонный звонок
        PhoneCallManager.Instance.StartPhoneCall(phoneCallData);
        
        // Отключаем предмет
        gameObject.SetActive(false);
    }
}