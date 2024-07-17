using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseGameButton : MonoBehaviour
{
    [SerializeField] private Button _chooseGameButton;
    [SerializeField] private MainMenuGroupObjects _mainMenuUI;
    [SerializeField] private MainMenuGroupObjects _preGameScreenUI;

    private void LoadPreGameScreen()
    {
        Time.timeScale = 1.0f;
        _preGameScreenUI.Show();
        _mainMenuUI.Hide();
    }

    private void OnEnable()
    {
        if (_chooseGameButton != null)
        {
            _chooseGameButton.onClick.AddListener(LoadPreGameScreen);
        }
        else
        {
            Debug.LogError("No game is existing");
        }
    }

    private void OnDisable()
    {
        if (_chooseGameButton != null)
        {
            _chooseGameButton.onClick.RemoveListener(LoadPreGameScreen);
        }
    }

}
