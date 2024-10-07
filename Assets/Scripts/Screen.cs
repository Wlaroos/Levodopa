using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Screen : MonoBehaviour
{
    [SerializeField] private string _screenName;
    public string ScreenName => _screenName;
    
    private int _screenIndex;
    public int ScreenIndex
    {
        get => _screenIndex;
        set => _screenIndex = value;
    }
    
    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = _screenName;
        transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = ScreenIndex.ToString();
    }
}
