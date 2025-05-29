using UnityEngine;
using TMPro;

[CreateAssetMenu(fileName = "NewPhoneCall", menuName = "Phone Call System/Phone Call Data TMP")]
public class PhoneCallData : ScriptableObject
{
    [Header("Call Settings")]
    public string callerName;
    public Sprite callerImage;
    
    [Header("Text Settings")]
    [TextArea(3, 10)] public string messageText;
    public float charactersPerSecond = 20f;
    public float delayBeforeDisappear = 2f;
    
    [Header("Appearance")]
    public Color textColor = Color.white;
    public TMP_FontAsset textFontTMP;
    public int fontSize = 24;
}