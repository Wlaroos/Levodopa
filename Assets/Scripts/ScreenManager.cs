using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private List<GameObject> _screens;
    private GameObject _currentScreen;
    private GameObject _previousScreen;
    private int _currentScreenIndex;
    
    private void Awake()
    {
        _screens = new List<GameObject>();
        for (int i = 0; i < transform.childCount; i++)
        {
            _screens.Add(transform.GetChild(i).gameObject);
            _screens[i].GetComponent<Screen>().ScreenIndex = i;
        }
        _currentScreen = _screens[0];
        _currentScreenIndex = 0;
        
        for (int i = 1; i < _screens.Count; i++)
        {
            _screens[i].SetActive(false);
        }
        _currentScreen.SetActive(true);
    }
    
    public void NextScreen()
    {
        if (_currentScreenIndex < _screens.Count - 1)
        {
            _currentScreenIndex++;
            _previousScreen = _currentScreen;
            _currentScreen = _screens[_currentScreenIndex];
            _previousScreen.SetActive(false);
            _currentScreen.SetActive(true);
        }
        else
        {
            _previousScreen = _currentScreen;
            _currentScreen = _screens[0];
            _previousScreen.SetActive(false);
            _currentScreen.SetActive(true);
            _currentScreenIndex = 0;
        }
    }
    
    public void PreviousScreen()
    {
        if (_currentScreenIndex > 0)
        {
            _currentScreenIndex--;
            _previousScreen = _currentScreen;
            _currentScreen = _screens[_currentScreenIndex];
            _previousScreen.SetActive(false);
            _currentScreen.SetActive(true);
        }
        else
        {
            _previousScreen = _currentScreen;
            _currentScreen = _screens[_screens.Count - 1];
            _previousScreen.SetActive(false);
            _currentScreen.SetActive(true);
            _currentScreenIndex = _screens.Count - 1;
        }
    }
}
