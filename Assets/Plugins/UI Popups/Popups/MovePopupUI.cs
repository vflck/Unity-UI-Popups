using System.Collections;
using UnityEngine;
using UIPopups.EasingFunctions;

namespace UIPopups
{
    [RequireComponent(typeof(RectTransform))]
    [AddComponentMenu("UI Popup/Move Popup")]
    public class MovePopupUI : BasePopupUI
    {
        [Space, Header("MOVE SETTINGS:")]
        [SerializeField] private RectTransform targetTransform;
        [Space]
        [SerializeField] private Vector2 anchoredPositionHided;
        [SerializeField] private Vector2 anchoredPositionBeforeShowed;
        [SerializeField] private Vector2 anchoredPositionShowed;

        private void Reset()
        {
            targetTransform = GetComponent<RectTransform>();
        }
        
        protected override IEnumerator ShowAnimation(bool show)
        {
            var function = Easing.GetEaseFunction(easeType);

            targetTransform.anchoredPosition = anchoredPositionBeforeShowed;
            Vector2 startPosition = show ? anchoredPositionBeforeShowed : anchoredPositionShowed;
            Vector2 endPosition = show ? anchoredPositionShowed : anchoredPositionHided;

            float elapsedTime = 0;
            while (elapsedTime <= animationTime)
            {
                targetTransform.anchoredPosition = Vector3.LerpUnclamped(startPosition, endPosition,
                                                    Easing.Calculate(elapsedTime / animationTime, function));

                elapsedTime += useScaledTime ? Time.deltaTime : Time.unscaledDeltaTime;
                yield return null;
            }
            targetTransform.anchoredPosition = endPosition;

            ChangeStateTo(show);
        }
        
        protected override void ShowInstant(bool show)
        {
            targetTransform.anchoredPosition = show ? anchoredPositionShowed : anchoredPositionHided;
            ChangeStateTo(show);
        }
    }
}
