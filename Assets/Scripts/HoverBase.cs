using UnityEngine.Events;
using UnityEngine;


public class HoverBase : MonoBehaviour
{
    public UnityEvent _event;
    protected UnityAction _action;
    
    private Material _defaultMat;
    private Material _outlineMat;

    private SpriteRenderer _sr;
    protected RoomManager _rm;
    
    private bool _once = false;

    protected virtual void Awake()
    {
        //_defaultMat = Resources.Load<Material>("Materials/Default");
        //_outlineMat = Resources.Load<Material>("Materials/Outline");

        _sr = GetComponent<SpriteRenderer>();
        
        _rm = FindObjectOfType<RoomManager>();
    }
    
    private void OnMouseOver()
    {
        if (!_once)
        {
            //_sr.material = _outlineMat;
            _sr.color = new Color32(255,200,200,255);
            _once = true;
        }
    }

    private void OnMouseExit()
    {
        //_sr.material = _defaultMat;
        _sr.color = Color.white;
        _once = false;
    }

    private void OnMouseDown()
    {
        _event.Invoke();
        
        //_sr.material = _defaultMat;
        _sr.color = Color.white;
        _once = false;
    }
}
