using System;
using System.Collections;
using UnityEngine;

public abstract class BasePopupUI : MonoBehaviour
{
    public bool IsShowing { get; protected set; }
    public Action OnShowed, OnHided;

    public void Show(bool show)
    {
        if (showCoroutine != null)
            StopCoroutine(showCoroutine);
        
        showCoroutine = StartCoroutine(ShowAnimation(show));
    }
    
    private Coroutine showCoroutine;
    protected abstract IEnumerator ShowAnimation(bool show);

    protected void ChangeStateTo(bool newState)
    {
        IsShowing = newState;

        if (newState)
            OnShowed?.Invoke();
        else
            OnHided?.Invoke();
    }
}
