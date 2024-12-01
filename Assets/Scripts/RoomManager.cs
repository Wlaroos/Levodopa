using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    private GameObject _currentRoom;
    
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
    }
    
    public void ShowStorageRoom()
    {
        _currentRoom.SetActive(false);
        _storageRoom.SetActive(true);
        
        ShowSmallBackgroundWalls();
        
        _currentRoom = _storageRoom;
    }
    
    public void ShowScrawlRoom()
    {
        _currentRoom.SetActive(false);
        _scrawlRoom.SetActive(true);
        
        ShowBackgroundWalls();
        
        _currentRoom = _scrawlRoom;
    }

    public void ShowDoubleDoors()
    {
        _currentRoom.SetActive(false);
        _doubleDoors.SetActive(true);
        
        ShowBackgroundWalls();
        
        _currentRoom = _doubleDoors;
    }

    public void ShowEntranceDoor()
    {
        _currentRoom.SetActive(false);
        _entranceDoor.SetActive(true);
        
        ShowBackgroundWalls();
        
        _currentRoom = _entranceDoor;
    }

    public void ShowMinigameAndPC()
    {
        _currentRoom.SetActive(false);
        _miniGameAndPC.SetActive(true);
        
        ShowBackgroundWalls();
        
        _currentRoom = _miniGameAndPC;
    }

    public void ShowScrawlRoomDoor()
    {
        _currentRoom.SetActive(false);
        _scrawlRoomDoor.SetActive(true);
        
        ShowBackgroundWalls();
        
        _currentRoom = _scrawlRoomDoor;
    }

    public void ShowFilingCabinetClose()
    {
        _currentRoom.SetActive(false);
        _filingCabinetClose.SetActive(true);
        
        ShowNoWalls();
        
        _currentRoom = _filingCabinetClose;
    }

    public void ShowKeypadClose()
    {
        _currentRoom.SetActive(false);
        _keypadClose.SetActive(true);
        
        ShowNoWalls();
        
        _currentRoom = _keypadClose;
    }

    public void ShowPCDDeskClose()
    {
        _currentRoom.SetActive(false);
        _pcDeskClose.SetActive(true);
        
        ShowNoWalls();
        
        _currentRoom = _pcDeskClose;
    }

    public void ShowTrashcanClose()
    {
        _currentRoom.SetActive(false);
        _trashcanClose.SetActive(true);
        
        ShowNoWalls();
        
        _currentRoom = _trashcanClose;
    }
}
