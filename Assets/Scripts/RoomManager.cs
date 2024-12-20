using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject _startCanvas;
    [Space]
    [SerializeField] private GameObject _bg;
    [SerializeField] private GameObject _bgWalls;
    [SerializeField] private GameObject _bgSmallRoomWalls;
    [Space]
    [SerializeField] private GameObject _anatomyRoom;
    [SerializeField] private GameObject _storageRoom;
    [SerializeField] private GameObject _scrawlRoom;
    [Space]
    [SerializeField] private GameObject _doubleDoors;
    [SerializeField] private GameObject _entranceDoor;
    [SerializeField] private GameObject _miniGameAndPC;
    [SerializeField] private GameObject _scrawlRoomDoor;
    [Space]
    [SerializeField] private GameObject _filingCabinetClose;
    [SerializeField] private GameObject _keypadClose;
    [SerializeField] private GameObject _pcDeskClose;
    [SerializeField] private GameObject _trashcanClose;
    [Space]
    [SerializeField] private GameObject _backButton;
    [SerializeField] private GameObject _leftButton;
    [SerializeField] private GameObject _rightButton;
    
    public GameObject _currentRoom;
    
    private UnityAction _backAction;
    private UnityAction _leftAction;
    private UnityAction _rightAction;

    private bool _isPopup;
    public int _popupsOpen;
    
    private void Awake()
    {
        _currentRoom = _entranceDoor;
    }

    public void ShowBackground()
    {
        _bg.SetActive(true);
    }
    public void HideBackground()
    {
        _bg.SetActive(false);
    }

    private void ShowBackButton()
    {
        _backButton.SetActive(true);
        
        // I don't know why this has to be here. It breaks if I put it in SetButtonListeners. Wasted like 2 hours trying to figure this out.
        _backButton.GetComponent<HoverRoomChange>()._event.RemoveAllListeners();
        _backButton.GetComponent<HoverRoomChange>()._event.AddListener(_backAction);
    }
    private void HideBackButton()
    {
        _backButton.SetActive(false);
    }
    private void ShowSideButtons()
    {
        _leftButton.SetActive(true);
        _rightButton.SetActive(true);
    }
    private void HideSideButtons()
    {
        _leftButton.SetActive(false);
        _rightButton.SetActive(false);
    }

    private void SetButtonListeners()
    {
        _leftButton.GetComponent<HoverRoomChange>()._event.RemoveAllListeners();
        _rightButton.GetComponent<HoverRoomChange>()._event.RemoveAllListeners();
        
        _leftButton.GetComponent<HoverRoomChange>()._event.AddListener(_leftAction);
        _rightButton.GetComponent<HoverRoomChange>()._event.AddListener(_rightAction);
    }

    private void ShowBackgroundWalls()
    {
        _bgWalls.SetActive(true);
        _bgSmallRoomWalls.SetActive(false);
        
        HideBackButton();
        ShowSideButtons();
    }

    private void ShowSmallBackgroundWalls()
    {
        _bgWalls.SetActive(false);
        _bgSmallRoomWalls.SetActive(true);
        
        ShowBackButton();
        HideSideButtons();
    }

    private void ShowNoWalls()
    {
        _bgWalls.SetActive(false);
        _bgSmallRoomWalls.SetActive(false);

        ShowBackButton();
        HideSideButtons();
    }

    public void ShowAnatomyRoom()
    {
        _currentRoom.SetActive(false);
        _anatomyRoom.SetActive(true);
        
        ShowSmallBackgroundWalls();
        
        _currentRoom = _anatomyRoom;
        _backAction = ShowAnatomyRoom;
        
        SetButtonListeners();
    }
    
    public void ShowStorageRoom()
    {
        _currentRoom.SetActive(false);
        _storageRoom.SetActive(true);
        
        ShowSmallBackgroundWalls();
        
        _currentRoom = _storageRoom;
        _backAction = ShowStorageRoom;
        
        SetButtonListeners();
    }
    
    public void ShowScrawlRoom()
    {
        _currentRoom.SetActive(false);
        _scrawlRoom.SetActive(true);
        
        _bgWalls.SetActive(true);
        _bgSmallRoomWalls.SetActive(false);
        
        ShowBackButton();
        HideSideButtons();
        
        _currentRoom = _scrawlRoom;
        _backAction = ShowScrawlRoom;
        
        SetButtonListeners();
    }

    public void ShowDoubleDoors()
    {
        _currentRoom.SetActive(false);
        _doubleDoors.SetActive(true);
        
        ShowBackgroundWalls();
        
        _currentRoom = _doubleDoors;
        _backAction = ShowDoubleDoors;
        
        _leftAction = ShowEntranceDoor;
        _rightAction = ShowMinigameAndPC;
        
        SetButtonListeners();
    }

    public void ShowEntranceDoor()
    {
        _currentRoom.SetActive(false);
        _entranceDoor.SetActive(true);
        
        ShowBackgroundWalls();
        
        _currentRoom = _entranceDoor;
        _backAction = ShowEntranceDoor;
        
        _leftAction = ShowScrawlRoomDoor;
        _rightAction = ShowDoubleDoors;
        
        SetButtonListeners();
    }

    public void ShowMinigameAndPC()
    {
        _currentRoom.SetActive(false);
        _miniGameAndPC.SetActive(true);
        
        ShowBackgroundWalls();
        
        _currentRoom = _miniGameAndPC;
        _backAction = ShowMinigameAndPC;
        
        _leftAction = ShowDoubleDoors;
        _rightAction = ShowScrawlRoomDoor;
        
        SetButtonListeners();
    }

    public void ShowScrawlRoomDoor()
    {
        _currentRoom.SetActive(false);
        _scrawlRoomDoor.SetActive(true);
        
        ShowBackgroundWalls();
        
        _currentRoom = _scrawlRoomDoor;
        _backAction = ShowScrawlRoomDoor;
        
        _leftAction = ShowMinigameAndPC;
        _rightAction = ShowEntranceDoor;
        
        SetButtonListeners();
    }

    public void ShowFilingCabinetClose()
    {
        _currentRoom.SetActive(false);
        _filingCabinetClose.SetActive(true);
        
        ShowNoWalls();
        
        _currentRoom = _filingCabinetClose;
        _backAction = ShowFilingCabinetClose;
        
        SetButtonListeners();
    }

    public void ShowKeypadClose()
    {
        _currentRoom.SetActive(false);
        _keypadClose.SetActive(true);
        
        ShowNoWalls();
        
        _currentRoom = _keypadClose;
        _backAction = ShowKeypadClose;
        
        SetButtonListeners();
    }

    public void ShowPCDeskClose()
    {
        _currentRoom.SetActive(false);
        _pcDeskClose.SetActive(true);
        
        ShowNoWalls();
        
        _currentRoom = _pcDeskClose;
        _backAction = ShowPCDeskClose;
        
        SetButtonListeners();
    }

    public void ShowTrashcanClose()
    {
        _currentRoom.SetActive(false);
        _trashcanClose.SetActive(true);
        
        ShowNoWalls();
        
        _currentRoom = _trashcanClose;
        _backAction = ShowTrashcanClose;
        
        SetButtonListeners();
    }
}
