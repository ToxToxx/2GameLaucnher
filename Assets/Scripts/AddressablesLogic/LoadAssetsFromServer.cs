using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LoadAssetsFromServer : MonoBehaviour
{
    [SerializeField] private Button _loadClickGameAssetsButton;
    [SerializeField] private Button _loadRunnerGameAssetsButton;

    private string _scene1Address = "clickgamepackedassets_scenes_all_18adbe70653bfdf222ed6a2188404f33.bundle";
    private string _scene2Address = "runnergamepackedassets_scenes_all_e5fb86d1632af0f0c9e89f935b224b79.bundle";

    private AsyncOperationHandle<SceneInstance> _currentSceneHandle;

    void Start()
    {
        _loadClickGameAssetsButton.onClick.AddListener(LoadClickGame);
        _loadRunnerGameAssetsButton.onClick.AddListener(LoadRunnerGame);
    }

    void LoadClickGame()
    {
        UnloadCurrentScene();

        Addressables.LoadSceneAsync(_scene1Address, LoadSceneMode.Single).Completed += SceneLoadedCallback;
    }

    void LoadRunnerGame()
    {
        UnloadCurrentScene();

        Addressables.LoadSceneAsync(_scene2Address, LoadSceneMode.Single).Completed += SceneLoadedCallback;
    }

    void SceneLoadedCallback(AsyncOperationHandle<SceneInstance> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            _currentSceneHandle = handle;
        }
        else
        {
            Debug.LogError("Failed to load scene: " + handle.DebugName);
        }
    }

    void UnloadCurrentScene()
    {
        if (_currentSceneHandle.IsValid())
        {
            Addressables.UnloadSceneAsync(_currentSceneHandle);
        }
    }
}
