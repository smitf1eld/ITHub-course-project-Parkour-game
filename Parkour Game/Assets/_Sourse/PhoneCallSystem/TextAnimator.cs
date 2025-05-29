using UnityEngine;
using TMPro;
using System.Collections;

[RequireComponent(typeof(TMP_Text))]
public class TextAnimatorTMP : MonoBehaviour
{
    private TMP_Text tmpComponent;
    private string fullText;
    private float speed;
    private Coroutine animationCoroutine;

    private void Awake()
    {
        tmpComponent = GetComponent<TMP_Text>();
    }

    public void AnimateText(string text, float charactersPerSecond)
    {
        fullText = text;
        speed = 1f / charactersPerSecond;
        
        if (animationCoroutine != null)
            StopCoroutine(animationCoroutine);
            
        animationCoroutine = StartCoroutine(AnimateTextCoroutine());
    }

    private IEnumerator AnimateTextCoroutine()
    {
        tmpComponent.text = "";
        float progress = 0f;
        
        for (int i = 0; i < fullText.Length; i++)
        {
            tmpComponent.text += fullText[i];
            progress = (float)i / fullText.Length;
            PhoneCallEvents.OnTextProgress.Invoke(progress);
            yield return new WaitForSeconds(speed);
        }
        
        PhoneCallEvents.OnTextProgress.Invoke(1f);
    }

    public void SkipAnimation()
    {
        if (animationCoroutine != null)
        {
            StopCoroutine(animationCoroutine);
            tmpComponent.text = fullText;
            PhoneCallEvents.OnTextProgress.Invoke(1f);
        }
    }
}