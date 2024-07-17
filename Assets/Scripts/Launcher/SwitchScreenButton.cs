using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchScreenButton : MonoBehaviour
{
    [SerializeField] private Button _switchScreenButton;
    [SerializeField] private MainMenuGroupObjects _screenToHide;
    [SerializeField] private MainMenuGroupObjects _screenToShow;

    private void LoadPreGameScreen()
    {
        _screenToShow.Show();
        _screenToHide.Hide();
    }

    private void OnEnable()
    {
        if (_switchScreenButton != null)
        {
            _switchScreenButton.onClick.AddListener(LoadPreGameScreen);
        }
        else
        {
            Debug.LogError("No button found");
        }
    }

    private void OnDisable()
    {
        if (_switchScreenButton != null)
        {
            _switchScreenButton.onClick.RemoveListener(LoadPreGameScreen);
        }
    }

}
