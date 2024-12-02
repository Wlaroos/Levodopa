using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InspectPopup : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    private TextMeshProUGUI _textMesh;
    
    private float _delayTime = 2f;
    private float _fadeTime = 0.5f;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
        
        _canvasGroup.alpha = 0;
    }

    public void Inspect(string text)
    {
        _textMesh.text = text;
        
        StopAllCoroutines();
        StartCoroutine(PopupFade());
    }

    private IEnumerator PopupFade()
    {
        float timeElapsed = 0;
        _canvasGroup.alpha = 1;
        
        yield return new WaitForSeconds(_delayTime);
        
        while (timeElapsed < _fadeTime)
        {
            _canvasGroup.alpha = Mathf.Lerp(1, 0, timeElapsed / _fadeTime);
            timeElapsed += Time.deltaTime;
            
            yield return null;
        }
        
        _canvasGroup.alpha = 0;
    }
}
