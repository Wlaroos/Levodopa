using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectPopup : MonoBehaviour
{
    [SerializeField] private Image _itemImage;
    [SerializeField] private TextMeshProUGUI _itemName;

    private GameObject _gameObject;
    
    public void Collect(Sprite sprite, string text, GameObject thing)
    {
        _itemImage.sprite = sprite;
        _itemName.text = "- " + text + " -";
        _gameObject = thing;
    }

    public void ShowObject()
    {
        _gameObject.SetActive(true);
    }
}