using UnityEngine.Events;
using UnityEngine;


public class HoverInspect : HoverBase
{
    [SerializeField] private string _description;
    
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        _ip.Inspect(_description);
    }
    
}
