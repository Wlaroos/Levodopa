using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private string _screenName;
    public string ScreenName => _screenName;

    private RoomManager _rm;
    
    private void Awake()
    {
        if (transform.GetChild(0).Find("Screen Name") != null)
        {
            transform.GetChild(0).Find("Screen Name").GetComponent<TextMeshProUGUI>().text = _screenName;
        }

        if (FindObjectOfType<RoomManager>() != null)
        {
            _rm = FindObjectOfType<RoomManager>();
        }

        HidePopup();
    }
    
    public void HidePopup()
    {
        gameObject.SetActive(false);
        HowManyPopups();
    }
    
    public void ShowPopup()
    {
        gameObject.SetActive(true);
        HowManyPopups();
    }

    private void HowManyPopups()
    {
        _rm._popupsOpen = 0;
        foreach (var pop in FindObjectsOfType<Popup>())
        {
            if (pop.isActiveAndEnabled)
            {
                _rm._popupsOpen += 1;
            }
        }
    }
}
