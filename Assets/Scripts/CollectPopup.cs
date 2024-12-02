using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CollectPopup : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemName;
    
    private float _delayTime = 1.5f;
    private float _fadeTime = .66f;

    private bool _once;
    
    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        
        _canvasGroup.alpha = 0;
    }

    public void Collect(Sprite sprite, string text)
    {
        _itemImage.sprite = sprite;
        _itemName.text = "Picked up: " + text;
        _canvasGroup.alpha = 1;
        
        StopAllCoroutines();
        StartCoroutine(PopupFade());
    }
    
    private IEnumerator PopupFade()
    {
        _once = true;
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
        _once = false;
    }
}