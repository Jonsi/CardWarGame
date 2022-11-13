using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Image _image;

    [SerializeField] private Sprite _sprite;

    [SerializeField] private Button _button;
    // Start is called before the first frame update
    void Start()
    {
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnClick()
    {
        _image.sprite = _sprite;
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnClick);
    }
}
