using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DoubleClick : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Use One of these")]
    [SerializeField] private bool _useToggle;
    [SerializeField] private bool _enableObjects;
    [Header("Is it a double click?")]
    [SerializeField] private bool _doubleClick;
    [Header("Objects that will be affected")]
    [SerializeField] private GameObject[] _objects;
    [Header("Image to darken on hover")]
    [SerializeField] private Image _imageToChange;
    
    public UnityEvent _event;
    
    private Color _color;
    private Color _initialColor;
    private bool _isToggled;

    private void Awake()
    {
        if(_imageToChange == null && GetComponent<Image>() != null)
        {
            _imageToChange = GetComponent<Image>();
        }
        
        _initialColor = _imageToChange.color;
        _color = new Color(_initialColor.r - 0.125f, _initialColor.g - 0.125f, _initialColor.b - 0.125f, 0.5f);
        
    }

    private void OnDisable()
    {
        _isToggled = false;
        _imageToChange.color = _initialColor;
    }

    public void OnPointerClick(PointerEventData data)
    {
        if (data.clickCount >= 1 && !_doubleClick)
        {
            SingleClicked();
        }
        else if (data.clickCount >= 2 && _doubleClick)
        {
            DoubleClicked();
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {
        _imageToChange.color = _color;
    }

    public void OnPointerExit(PointerEventData data)
    {
        _imageToChange.color = _initialColor;
    }

    private void Toggle()
    {
        if (_useToggle)
        {
            foreach (var obj in _objects)
            {
                _isToggled = !_isToggled;
                obj.SetActive(_isToggled);
            }
        }
        else
        {
            if(_enableObjects)
            {
                foreach (var obj in _objects)
                {
                    if (obj.GetComponent<Popup>() != null)
                    {
                        obj.GetComponent<Popup>().ShowPopup();
                    }
                    else
                    {
                        obj.SetActive(true);
                    }
                }
            }
            else
            {
                foreach (var obj in _objects)
                {
                    if (obj.GetComponent<Popup>() != null)
                    {
                        obj.GetComponent<Popup>().HidePopup();
                    }
                    else
                    {
                        obj.SetActive(false);
                    }
                }
            }
        }
        
        _event.Invoke();
    }
    
    private void SingleClicked()
    {
        Debug.Log("Single click");
        Toggle();
    }
    
    private void DoubleClicked()
    {
        Debug.Log("Double click");
        Toggle();
    }
}
