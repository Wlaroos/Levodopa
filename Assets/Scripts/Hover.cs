using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Hover : MonoBehaviour
{
    public UnityEvent _event;
    private UnityAction _action;
    
    private Material _defaultMat;
    private Material _outlineMat;

    private SpriteRenderer _sr;
    private RoomManager _rm;
    
    private bool _once = false;
    
    public enum RoomToOpen 
    {
        AnatomyRoom,
        StorageRoom,
        ScrawlRoom,
        DoubleDoors,
        EntranceDoor,
        MinigameAndPC,
        ScrawlRoomDoor,
        FilingCabinetClose,
        KeypadClose,
        PCDDeskClose,
        TrashcanClose
    };

    [SerializeField] public RoomToOpen roomToOpen;

    private void Awake()
    {
        _defaultMat = Resources.Load<Material>("Materials/Default");
        _outlineMat = Resources.Load<Material>("Materials/Outline");

        _sr = GetComponent<SpriteRenderer>();
        
        _rm = FindObjectOfType<RoomManager>();

        switch (roomToOpen)
        {
            case RoomToOpen.AnatomyRoom:
                _action = _rm.ShowAnatomyRoom;
                break;
            case RoomToOpen.StorageRoom:
                _action = _rm.ShowStorageRoom;
                break;
            case RoomToOpen.ScrawlRoom:
                _action = _rm.ShowScrawlRoom;
                break;
            case RoomToOpen.DoubleDoors:
                _action = _rm.ShowDoubleDoors;
                break;
            case RoomToOpen.EntranceDoor:
                _action = _rm.ShowEntranceDoor;
                break;
            case RoomToOpen.MinigameAndPC:
                _action = _rm.ShowMinigameAndPC;
                break;
            case RoomToOpen.ScrawlRoomDoor:
                _action = _rm.ShowScrawlRoomDoor;
                break;
            case RoomToOpen.FilingCabinetClose:
                _action = _rm.ShowFilingCabinetClose;
                break;
            case RoomToOpen.KeypadClose:
                _action = _rm.ShowKeypadClose;
                break;
            case RoomToOpen.PCDDeskClose:
                _action = _rm.ShowPCDDeskClose;
                break;
            case RoomToOpen.TrashcanClose:
                _action = _rm.ShowTrashcanClose;
                break;
            default:
                _action = _rm.ShowEntranceDoor;
                break;
        }
        
        UnityEventTools.AddPersistentListener(_event, _action);
    }
    
    private void OnMouseOver()
    {
        if (!_once)
        {
            _sr.material = _outlineMat;
            _once = true;
        }
    }

    private void OnMouseExit()
    {
        _sr.material = _defaultMat;
        _once = false;
    }

    private void OnMouseDown()
    {
        _event.Invoke();
    }
}
