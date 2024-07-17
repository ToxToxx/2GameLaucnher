using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadAssetsLocal : MonoBehaviour
{
    [SerializeField] private Button _loadClickGameAssetsButton;
    [SerializeField] private Button _unloadClickGameAssetsButton;
    [SerializeField] private Button _loadRunnerGameAssetsButton;
    [SerializeField] private Button _unloadRunnerGameAssetsButton;

    private string _clickGameAssetsKey = "Assets/Scenes/ClickGame1.unity";
    private string _runnerGameAssetsKey = "Assets/Scenes/RunGame2.unity";

    private List<AsyncOperationHandle> _loadedClickGameAssetsHandles = new List<AsyncOperationHandle>();
    private List<AsyncOperationHandle> _loadedRunnerGameAssetsHandles = new List<AsyncOperationHandle>();

    void Start()
    {
        _loadClickGameAssetsButton.onClick.AddListener(LoadClickGameAssets);
        _unloadClickGameAssetsButton.onClick.AddListener(UnloadClickGameAssets);
        _loadRunnerGameAssetsButton.onClick.AddListener(LoadRunnerGameAssets);
        _unloadRunnerGameAssetsButton.onClick.AddListener(UnloadRunnerGameAssets);
    }

    void LoadClickGameAssets()
    {
        Addressables.LoadAssetAsync<Object>(_clickGameAssetsKey).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _loadedClickGameAssetsHandles.Add(handle);
                Debug.Log("Click Game assets loaded successfully.");
            }
            else
            {
                Debug.LogError("Failed to load Click Game assets.");
            }
        };
    }

    void UnloadClickGameAssets()
    {
        foreach (var handle in _loadedClickGameAssetsHandles)
        {
            Addressables.Release(handle);
        }
        _loadedClickGameAssetsHandles.Clear();
        Debug.Log("Click Game assets unloaded successfully.");
    }

    void LoadRunnerGameAssets()
    {
        Addressables.LoadAssetAsync<Object>(_runnerGameAssetsKey).Completed += handle =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                _loadedRunnerGameAssetsHandles.Add(handle);
                Debug.Log("Runner Game assets loaded successfully.");
            }
            else
            {
                Debug.LogError("Failed to load Runner Game assets.");
            }
        };
    }

    void UnloadRunnerGameAssets()
    {
        foreach (var handle in _loadedRunnerGameAssetsHandles)
        {
            Addressables.Release(handle);
        }
        _loadedRunnerGameAssetsHandles.Clear();
        Debug.Log("Runner Game assets unloaded successfully.");
    }
}
