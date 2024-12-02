using UnityEngine;

public class HoverCollect : HoverBase
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private string _itemName;
    [Space]
    [SerializeField] private GameObject _thingToShow;
    [Space]
    [SerializeField]private GameObject _collectPopup;
    
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

        CollectPopup cp = Instantiate(_collectPopup, transform.position, transform.rotation).GetComponent<CollectPopup>();
        Popup pu = cp.gameObject.GetComponent<Popup>();
        cp.Collect(_sprite, _itemName, _thingToShow);
        pu.ShowPopup();
        
        Destroy(gameObject);
    }
}
