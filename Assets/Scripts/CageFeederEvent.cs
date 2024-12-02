using UnityEngine;

public class CageFeederEvent : HoverInspect
{
    [SerializeField] private GameObject _mouseBites;
    
    protected override void OnMouseDown()
    {
        if (_rm._popupsOpen <= 0)
        {
            if (_mouseBites.activeSelf)
            {
                _event.Invoke();
                Destroy(_mouseBites);
            }
            else
            {
                _ip.Inspect(_description);
            }
        }
    }
}
