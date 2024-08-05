using UnityEngine;
using UnityEngine.UI;

public class LoadNextSceneButton : MonoBehaviour
{
    /// <summary>
    /// Script that allows navigation to another scene - mainly used for returning to the main menu.
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
            Debug.LogError("No button assigned for scene loading.");
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
