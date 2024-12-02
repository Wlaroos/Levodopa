using UnityEngine.Events;
using UnityEngine;


public class HoverInspect : HoverBase
{
    [SerializeField] protected string _description;
    
    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        if (_rm._popupsOpen <= 0)
        {
            _ip.Inspect(_description);
        }
    }
    
}
