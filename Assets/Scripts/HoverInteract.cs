using UnityEngine.Events;
using UnityEngine;


public class HoverInteract : HoverBase
{
    [SerializeField] private string _description;
    
    protected override void Awake()
    {
        base.Awake();
        if (_action != null)
        {
            _event.AddListener(_action);
        }
    }
    
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        _ip.Inspect(_description);
    }
}
