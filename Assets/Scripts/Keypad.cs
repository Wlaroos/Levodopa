using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Keypad : MonoBehaviour
{
    public UnityEvent _event;
    
    private TextMeshPro[] _inputs = new TextMeshPro[4];
    private KeypadButtons[] _keypadButtons = new KeypadButtons[12];

    private int _currentInputIndex = 0;

    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            _inputs[i] = transform.GetChild(i).GetComponent<TextMeshPro>();
        }
        for (int i = 0; i < 12; i++)
        {
            _keypadButtons[i] = transform.GetChild(i + 4).GetComponent<KeypadButtons>();
        }
    }

    public void ButtonPressed(string input)
    {
        if (input == "C")
        {
            _currentInputIndex = 0;
            foreach (var text in _inputs)
            {
                text.text = "-";
            }
        }
        else
        {
            _inputs[_currentInputIndex].text = input;
            _currentInputIndex++;
        }

        if (_currentInputIndex >= 4)
        {
            if (_inputs[0].text + _inputs[1].text + _inputs[2].text + _inputs[3].text == "2703")
            {
                foreach (var text in _inputs)
                {
                    text.color = new Color32(112,221,169,255);
                }

                foreach (var button in _keypadButtons)
                {
                    Destroy(button);
                }

                _event.Invoke();
            }
            else
            {
                StopAllCoroutines();
                StartCoroutine(WrongAnswer());
            }
        }
    }

    private IEnumerator WrongAnswer()
    {
        yield return new WaitForSeconds(0.5f);
        
        _currentInputIndex = 0;
        foreach (var text in _inputs)
        {
            text.text = "-";
        }
    }
    
    
}
