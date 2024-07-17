using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButtonUI : MonoBehaviour
{
    [SerializeField] private Loader.Scene _concreteScene;
    [SerializeField] private Button _startGameButton;
    private void LoadGame()
    {
        Loader.Load(_concreteScene);
    }

    private void OnEnable()
    {
        if (_startGameButton != null)
        {
            _startGameButton.onClick.AddListener(LoadGame);
        }
        else
        {
            Debug.LogError("No game is existing");
        }
    }

    private void OnDisable()
    {
        if (_startGameButton != null)
        {
            _startGameButton.onClick.RemoveListener(LoadGame);
        }
    }

}
