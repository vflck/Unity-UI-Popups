using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
[AddComponentMenu("UI Popup/Fade Popup")]
public class FadePopupUI : BasePopupUI
{
    [SerializeField] private CanvasGroup targetCanvasGroup;
    [Header("PREFERENCES:")]
    [SerializeField, Range(0,1)] private float opacityHided = 0f;
    [SerializeField, Range(0,1)] private float opacityShowed = 1f;
    [Space(7)]
    [SerializeField, Min(0)] private float animationTime = 0.15f;
    [SerializeField] private bool useScaledTime = true;

    private void Reset()
    {
        targetCanvasGroup = GetComponent<CanvasGroup>();
    }

    protected override IEnumerator ShowAnimation(bool show)
    {
        float startAlpha = targetCanvasGroup.alpha;
        float endAlpha = show ? opacityShowed : opacityHided;

        float elapsedTime = 0;
        while (elapsedTime <= animationTime)
        {
            targetCanvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / animationTime);

            elapsedTime += useScaledTime ? Time.deltaTime : Time.unscaledDeltaTime;
            yield return null;
        }
        targetCanvasGroup.alpha = endAlpha;

        ChangeStateTo(show);
    }
}
