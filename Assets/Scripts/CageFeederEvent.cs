using UnityEngine;

public class CageFeederEvent : HoverInspect
{
    [SerializeField] private GameObject _mouseBites;
    
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
        if (_rm._popupsOpen <= 0)
        {
            _ip.Inspect(_description);
            
            if (_mouseBites.activeSelf)
            {
                _event.Invoke();
                Destroy(_mouseBites);
            }
        }
    }
}
