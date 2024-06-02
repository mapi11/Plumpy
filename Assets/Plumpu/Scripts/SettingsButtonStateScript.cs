using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsButtonStateScript : MonoBehaviour
{
    public Sprite _imgBlue;
    public Sprite _imgGray;
    private Button _button;
    private SpriteState _spriteState;
    private bool isToggled = false;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ToggleSprite);
    }

    public void ToggleSprite()
    {

        if (isToggled)
        {
            isToggled = !isToggled;
            _button.image.sprite = _imgGray;

            _spriteState.pressedSprite = _imgBlue;
            _spriteState.disabledSprite = _imgBlue;
            _button.spriteState = _spriteState;
        }
        else
        {
            _button.image.sprite = _imgBlue;
            isToggled = true;

            _spriteState.pressedSprite = _imgGray;
            _spriteState.disabledSprite = _imgGray;
            _button.spriteState = _spriteState;
        }
    }
}
