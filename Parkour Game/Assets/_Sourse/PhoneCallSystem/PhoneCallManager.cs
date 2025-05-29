using UnityEngine;

public class PhoneCallManager : MonoBehaviour
{
    public static PhoneCallManager Instance { get; private set; }

    [SerializeField] private PhoneCallUITMP phoneCallUI;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartPhoneCall(PhoneCallData callData)
    {
        PhoneCallEvents.OnCallStart.Invoke(callData);
    }
}