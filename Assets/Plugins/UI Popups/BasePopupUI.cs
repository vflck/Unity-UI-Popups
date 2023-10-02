using System;
using System.Collections;
using UnityEngine;

public abstract class BasePopupUI : MonoBehaviour
{
    public bool IsShowing { get; protected set; }
    public Action OnShowed, OnHided;

    [SerializeField] private bool initialHided = false;
    [SerializeField] private bool disableOnHide = true;
    
    [Header("TIME SETTINGS:")]
    [SerializeField, Min(0)] protected float animationTime = 0.15f;
    [SerializeField] protected bool useScaledTime = true;

    private void Start()
    {
        ShowInstant(initialHided);
    }

    public void Show(bool show)
    {
        gameObject.SetActive(true);
        if (showCoroutine != null)
            StopCoroutine(showCoroutine);
        
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
