using UnityEngine.Events;
using UnityEngine;


public class HoverInspect : HoverBase
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
    
}
