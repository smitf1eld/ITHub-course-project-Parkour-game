using UnityEngine;
using UnityEngine.UI;
using System;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;
    
    private bool isFading = false;
    
    public void StartFade(Action onComplete = null)
    {
        if (isFading || fadeImage == null) return;
        
        isFading = true;
        StartCoroutine(Fade(0f, 1f, fadeDuration, onComplete));
    }
    
    public void StartUnfade(Action onComplete = null)
    {
        if (isFading || fadeImage == null) return;
        
        isFading = true;
        StartCoroutine(Fade(1f, 0f, fadeDuration, onComplete));
    }
    
    private System.Collections.IEnumerator Fade(float from, float to, float duration, Action onComplete)
    {
        float elapsed = 0f;
        Color color = fadeImage.color;
        
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            color.a = Mathf.Lerp(from, to, elapsed / duration);
            fadeImage.color = color;
            yield return null;
        }
        
        color.a = to;
        fadeImage.color = color;
        isFading = false;
        onComplete?.Invoke();
    }
}