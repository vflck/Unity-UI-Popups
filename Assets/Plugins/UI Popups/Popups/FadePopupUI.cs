using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
[AddComponentMenu("UI Popup/Fade Popup")]
public class FadePopupUI : BasePopupUI
{
    [Space, Header("FADE SETTINGS:")]
    [SerializeField] private CanvasGroup targetCanvasGroup;
    [Space]
    [SerializeField, Range(0,1)] private float opacityHided = 0f;
    [SerializeField, Range(0,1)] private float opacityShowed = 1f;

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

    protected override void ShowInstant(bool show)
    {
        targetCanvasGroup.alpha = show ? opacityShowed : opacityHided;
        ChangeStateTo(show);
    }
}
