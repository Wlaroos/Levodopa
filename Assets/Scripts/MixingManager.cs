using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MixingManager : MonoBehaviour
{
    private List<GameObject> _mixingContainers;
    private GameObject[] _mixingContainersArray;
    private int _currentMixingContainerIndex;
    private bool _full;

    private void Awake()
    {
        _mixingContainers = new List<GameObject>();
        for (int i = 0; i < transform.GetChild(0).transform.childCount; i++)
        {
            _mixingContainers.Add(transform.GetChild(0).GetChild(i).gameObject);
        }
        _mixingContainersArray = _mixingContainers.ToArray();
        _currentMixingContainerIndex = 0;
        _mixingContainersArray[_currentMixingContainerIndex].GetComponent<Image>().color = Color.gray;
    }
    
    public void AddBlue() => AddColor(Color.blue);
    public void AddRed() => AddColor(Color.red);
    public void AddYellow() => AddColor(Color.yellow);
    public void AddGreen() => AddColor(Color.green);
    public void AddPurple() => AddColor(new Color(0.5f, 0, 0.5f));
    public void AddOrange() => AddColor(new Color(1, 0.5f, 0));
    

    private void AddColor(Color color)
    {
        if (_currentMixingContainerIndex < _mixingContainers.Count - 1)
        {
            _mixingContainersArray[_currentMixingContainerIndex].GetComponent<Image>().color = color;
            _currentMixingContainerIndex++;
            _mixingContainersArray[_currentMixingContainerIndex].GetComponent<Image>().color = Color.gray;
        }
        else
        {
            if (!_full)
            {
                _mixingContainersArray[_currentMixingContainerIndex].GetComponent<Image>().color = color;
                Debug.Log("Mixing container is full");
            }
            _full = true;
        }
    }
    
    public void Mix()
    {
        Dictionary<string, int> colorCounts = new Dictionary<string, int>();

        for (int i = 0; i < _currentMixingContainerIndex; i++)
        {
            Color color = _mixingContainersArray[i].GetComponent<Image>().color;
            string colorString = ColorUtility.ToHtmlStringRGBA(color);
        
            if (colorCounts.ContainsKey(colorString))
            {
                colorCounts[colorString]++;
            }
            else
            {
                colorCounts[colorString] = 1;
            }
        }

        foreach (var colorCount in colorCounts)
        {
            Debug.Log($"<color=#{colorCount.Key}>Count: {colorCount.Value}</color>");
        }

        Clear();
    }

    
    public void Clear()
    {
        foreach (var ss in _mixingContainers)
        {
            ss.GetComponent<Image>().color = Color.black;
        }
        _currentMixingContainerIndex = 0;
        _mixingContainersArray[_currentMixingContainerIndex].GetComponent<Image>().color = Color.gray;
        _full = false;
        Debug.Log("Cleared");
    }
}