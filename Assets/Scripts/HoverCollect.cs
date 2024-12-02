using UnityEngine;

public class HoverCollect : HoverBase
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _itemName;
    
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
        _cp.Collect(_sprite, _itemName);
        
        Destroy(gameObject);
    }
}
