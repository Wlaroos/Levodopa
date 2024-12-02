using UnityEngine.Events;
using UnityEngine;

public class Hover : HoverBase
{
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
        PCDeskClose,
        TrashcanClose
    };

    [SerializeField] public RoomToOpen roomToOpen;

    protected override void Awake()
    {
        base.Awake();
        ActionSwitcher();
    }
    
    private void ActionSwitcher()
    {
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
            case RoomToOpen.PCDeskClose:
                _action = _rm.ShowPCDeskClose;
                break;
            case RoomToOpen.TrashcanClose:
                _action = _rm.ShowTrashcanClose;
                break;
            default:
                _action = _rm.ShowEntranceDoor;
                break;
        }
        
        _event.RemoveAllListeners();
        _event.AddListener(_action);
    }
}
