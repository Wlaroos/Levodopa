using UnityEngine.Events;
using UnityEngine;


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
        PCDeskClose,
        TrashcanClose
    };

    [SerializeField] public RoomToOpen roomToOpen;

    private void Awake()
    {
        _defaultMat = Resources.Load<Material>("Materials/Default");
        _outlineMat = Resources.Load<Material>("Materials/Outline");

        _sr = GetComponent<SpriteRenderer>();
        
        _rm = FindObjectOfType<RoomManager>();

        ActionSwitcher();
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
        
        _sr.material = _defaultMat;
        _once = false;
        
        Debug.Log(_rm._currentRoom);
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
