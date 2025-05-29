using UnityEngine.Events;

public static class PhoneCallEvents
{
    public static UnityEvent<PhoneCallData> OnCallStart = new UnityEvent<PhoneCallData>();
    public static UnityEvent OnCallComplete = new UnityEvent();
    public static UnityEvent<float> OnTextProgress = new UnityEvent<float>();
}