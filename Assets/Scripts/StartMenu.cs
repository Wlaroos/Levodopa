using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private CanvasGroup _canvasGroup;
        
    private float _delayTime = 0f;
    private float _fadeTime = 1f;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        
        _canvasGroup.alpha = 1;
    }
    
    public void StartFade()
    {
        StopAllCoroutines();
        StartCoroutine(ScreenFade());
    }

    private IEnumerator ScreenFade()
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
