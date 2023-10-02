using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
[AddComponentMenu("UI Popup/Scale Popup")]
public class ScalePopupUI : BasePopupUI
{
    [Space, Header("SCALE SETTINGS:")]
    [SerializeField] private RectTransform targetTransform;
    [Space]
    [SerializeField] private float scaleHided = 0f;
    [SerializeField] private float scaleShowed = 1f;

    private void Reset()
    {
        targetTransform = GetComponent<RectTransform>();
    }
    
    protected override IEnumerator ShowAnimation(bool show)
    {
        Vector3 startScale = targetTransform.localScale;
        Vector3 endScale = Vector3.one * (show ? scaleShowed : scaleHided);

        float elapsedTime = 0;
        while (elapsedTime <= animationTime)
        {
            targetTransform.localScale = Vector3.Lerp(startScale, endScale, elapsedTime / animationTime);

            elapsedTime += useScaledTime ? Time.deltaTime : Time.unscaledDeltaTime;
            yield return null;
        }
        targetTransform.localScale = endScale;

        ChangeStateTo(show);
    }
    
    protected override void ShowInstant(bool show)
    {
        targetTransform.localScale = Vector3.one * (show ? scaleShowed : scaleHided);
        ChangeStateTo(show);
    }
}
