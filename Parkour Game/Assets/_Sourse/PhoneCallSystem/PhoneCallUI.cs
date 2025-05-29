using UnityEngine;
using TMPro;
using DG.Tweening;

public class PhoneCallUITMP : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private UnityEngine.UI.Image callerImage;
    [SerializeField] private TMP_Text callerNameText;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private TextAnimatorTMP textAnimator;

    private PhoneCallData currentCallData;
    private Sequence showSequence;
    private Sequence hideSequence;

    private void Awake()
    {
        canvasGroup.alpha = 0f;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void OnEnable()
    {
        PhoneCallEvents.OnCallStart.AddListener(StartCall);
        PhoneCallEvents.OnTextProgress.AddListener(OnTextProgress);
    }

    private void OnDisable()
    {
        PhoneCallEvents.OnCallStart.RemoveListener(StartCall);
        PhoneCallEvents.OnTextProgress.RemoveListener(OnTextProgress);
    }

    private void StartCall(PhoneCallData callData)
    {
        currentCallData = callData;
        InitializeUI();
        ShowUI();
    }

    private void InitializeUI()
    {
        callerImage.sprite = currentCallData.callerImage;
        callerNameText.text = currentCallData.callerName;
        
        if (currentCallData.textFontTMP != null)
            messageText.font = currentCallData.textFontTMP;
            
        messageText.fontSize = currentCallData.fontSize;
        messageText.color = currentCallData.textColor;
    }

    private void ShowUI()
    {
        if (showSequence != null && showSequence.IsPlaying())
            showSequence.Kill();

        showSequence = DOTween.Sequence()
            .Append(canvasGroup.DOFade(1f, 0.5f))
            .OnComplete(() => {
                textAnimator.AnimateText(currentCallData.messageText, currentCallData.charactersPerSecond);
            });
    }

    private void HideUI()
    {
        if (hideSequence != null && hideSequence.IsPlaying())
            hideSequence.Kill();

        hideSequence = DOTween.Sequence()
            .Append(canvasGroup.DOFade(0f, 0.5f))
            .OnComplete(() => {
                PhoneCallEvents.OnCallComplete.Invoke();
            });
    }

    private void OnTextProgress(float progress)
    {
        if (progress >= 1f)
        {
            Invoke(nameof(HideUI), currentCallData.delayBeforeDisappear);
        }
    }
}