using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pages : MonoBehaviour
{

    [SerializeField] private Sprite[] _spriteList;

    [SerializeField] private Image _page01;
    [SerializeField] private Image _page02;

    [SerializeField] private Button _prevButton;
    [SerializeField] private Button _nextButton;

    [SerializeField] private bool _looping;

    private bool _isOnePage;
    private int _listSize;
    private int _page01Index;
    private int _page02Index;

    private void Awake()
    {
        if(_page02)
        {
            _isOnePage = false;
        }
        else
        {
            _isOnePage = true;
        }

        // I'm using arrays that start at index 0, so this needs to be -1 since it gives the length not the max index
        _listSize = _spriteList.Length - 1;

        if(_isOnePage)
        {
            _page01Index = 0;
            _page01.sprite = _spriteList[_page01Index];
        }
        else
        {
            _page01Index = 0;
            _page02Index = 1;
            _page01.sprite = _spriteList[_page01Index];
            _page02.sprite = _spriteList[_page02Index];
        }

        // Check for buttons
        UpdateImages();
    }

    public void NextPage()
    {
        if (_isOnePage)
        {
            if (_page01Index == _listSize && _looping)
            {
                _page01Index = 0;
            }
            else
            {
                _page01Index += 1;
            }
        }
        else
        {
            if (_page01Index == _listSize - 1 && _looping)
            {
                _page01Index = 0;
                _page02Index = 1;
            }
            else
            {
                _page01Index += 2;
                _page02Index += 2;
            }
        }

        UpdateImages();
    }

    public void PrevPage()
    {
        if (_isOnePage)
        {
            if (_page01Index == 0 && _looping)
            {
                _page01Index = _listSize;
            }
            else
            {
                _page01Index -= 1;
            }
        }
        else
        {
            if (_page01Index == 0 && _page02Index == 1 && _looping)
            {
                _page01Index = _listSize - 1;
                _page02Index = _listSize;
            }
            else
            {
                _page01Index -= 2;
                _page02Index -= 2;
            }
        }

        UpdateImages();
    }

    private void UpdateImages()
    {
        // Update Images
        _page01.sprite = _spriteList[_page01Index];

        if (!_isOnePage)
        {
            _page02.sprite = _spriteList[_page02Index];
        }


        // Hide Buttons if not needed and not looping
        if(!_looping)
        {
            if (_isOnePage)
            {
                if (_page01Index == 0)
                {
                    _prevButton.gameObject.SetActive(false);
                    _nextButton.gameObject.SetActive(true);
                }
                else if(_page01Index == _listSize)
                {
                    _nextButton.gameObject.SetActive(false);
                    _prevButton.gameObject.SetActive(true);
                }
                else
                {
                    _nextButton.gameObject.SetActive(true);
                    _prevButton.gameObject.SetActive(true);
                }
            }
            else
            {
                if (_page01Index == 0 && _page02Index == 1)
                {
                    _prevButton.gameObject.SetActive(false);
                    _nextButton.gameObject.SetActive(true);
                }
                else if(_page01Index == _listSize - 1 && _page02Index == _listSize)
                {
                    _nextButton.gameObject.SetActive(false);
                    _prevButton.gameObject.SetActive(true);
                }
                else
                {
                    _nextButton.gameObject.SetActive(true);
                    _prevButton.gameObject.SetActive(true);
                }
            }
        }
    }
}
