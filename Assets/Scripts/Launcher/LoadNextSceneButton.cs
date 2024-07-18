using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadNextSceneButton : MonoBehaviour
{
    /// <summary>
    /// —крипт, позвол€ющий отправитьс€ на другую сцену - сделан во многом дл€ того, чтобы вернутьс€ в главное меню
    /// </summary>
    [SerializeField] private Loader.Scene _concreteScene;
    [SerializeField] private Button _loadNextSceneButton;
    private void LoadGame()
    {
        Loader.Load(_concreteScene);
    }

    private void OnEnable()
    {
        if (_loadNextSceneButton != null)
        {
            _loadNextSceneButton.onClick.AddListener(LoadGame);
        }
        else
        {
            Debug.LogError("No scene is existing");
        }
    }

    private void OnDisable()
    {
        if (_loadNextSceneButton != null)
        {
            _loadNextSceneButton.onClick.RemoveListener(LoadGame);
        }
    }

}
