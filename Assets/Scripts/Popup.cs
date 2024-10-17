using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private string _screenName;
    public string ScreenName => _screenName;

    private void Awake()
    {
        transform.GetChild(0).Find("Screen Name").GetComponent<TextMeshProUGUI>().text = _screenName;

        HidePopup();
    }
    
    public void HidePopup()
    {
        gameObject.SetActive(false);
    }
    
    public void ShowPopup()
    {
        gameObject.SetActive(true);
    }
}
