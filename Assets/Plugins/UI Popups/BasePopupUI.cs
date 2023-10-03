using System;
using System.Collections;
using UnityEngine;
using UIPopups.EasingFunctions;

namespace UIPopups
{
    public abstract class BasePopupUI : MonoBehaviour
    {
        public bool IsShowing { get; protected set; }
        public Action OnShowed, OnHided;

        [SerializeField] private bool initialHided = true;
        [SerializeField] private bool disableOnHide = true;
        
        [Header("ANIMATION SETTINGS:")]
        [SerializeField] protected Ease easeType = Ease.InOutQuad;
        [SerializeField, Min(0)] protected float animationTime = 0.15f;
        [SerializeField] protected bool useScaledTime = true;

        private void Start()
        {
            ShowInstant(!initialHided);
        }

        public void Show(bool show)
        {
            if (show == IsShowing)
                return;

            gameObject.SetActive(true);
            if (showCoroutine != null) {
                StopCoroutine(showCoroutine);
            }
            
            showCoroutine = StartCoroutine(ShowAnimation(show));
        }
        
        private Coroutine showCoroutine;
        protected abstract IEnumerator ShowAnimation(bool show);
        protected abstract void ShowInstant(bool show);

        protected void ChangeStateTo(bool newState)
        {
            IsShowing = newState;

            if (newState)
            {
                OnShowed?.Invoke();
            }
            else
            {
                OnHided?.Invoke();
                if (disableOnHide)
                    gameObject.SetActive(false);
            }
        }
    }
}
