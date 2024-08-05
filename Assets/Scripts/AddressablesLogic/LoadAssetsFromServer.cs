using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

/// <summary>
/// Handles the loading and unloading of Addressable AssetBundles, in this case, scenes for the game.
/// </summary>
public class AssetManager : MonoBehaviour
{
    // Server URLs
    private readonly string _assetBundleURL1 = "https://storage.yandexcloud.net/unitytestzadanie/clickgamepackedassets_scenes_all_18adbe70653bfdf222ed6a2188404f33.bundle";
    private readonly string _assetBundleURL2 = "https://storage.yandexcloud.net/unitytestzadanie/runnergamepackedassets_scenes_all_e5fb86d1632af0f0c9e89f935b224b79.bundle";

    // Cached AssetBundles
    private AssetBundle _assetBundle1;
    private AssetBundle _assetBundle2;

    // UI elements
    [SerializeField] private Button _loadButton1;
    [SerializeField] private Button _loadButton2;
    [SerializeField] private Button _unloadButton1;
    [SerializeField] private Button _unloadButton2;
    [SerializeField] private TextMeshProUGUI _statusText;

    void Start()
    {
        // Add listeners to the buttons
        _loadButton1.onClick.AddListener(() => LoadAssetBundle(1));
        _loadButton2.onClick.AddListener(() => LoadAssetBundle(2));
        _unloadButton1.onClick.AddListener(() => UnloadAssetBundle(1));
        _unloadButton2.onClick.AddListener(() => UnloadAssetBundle(2));
    }

    // Method to load an asset
    private void LoadAssetBundle(int gameNumber)
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            _statusText.text = "No internet connection. Please check your connection and try again.";
            Debug.LogError("No internet connection.");
            return;
        }

        if (gameNumber == 1)
        {
            StartCoroutine(DownloadAssetBundle(_assetBundleURL1, 1));
        }
        else if (gameNumber == 2)
        {
            StartCoroutine(DownloadAssetBundle(_assetBundleURL2, 2));
        }
    }

    // Method to unload an asset
    private void UnloadAssetBundle(int gameNumber)
    {
        if (gameNumber == 1 && _assetBundle1 != null)
        {
            _assetBundle1.Unload(true);
            _assetBundle1 = null;
            _statusText.text = "AssetBundle 1 unloaded";
            Debug.Log("AssetBundle 1 unloaded");
        }
        else if (gameNumber == 2 && _assetBundle2 != null)
        {
            _assetBundle2.Unload(true);
            _assetBundle2 = null;
            _statusText.text = "AssetBundle 2 unloaded";
            Debug.Log("AssetBundle 2 unloaded");
        }
    }

    // Coroutine to download an AssetBundle
    private IEnumerator DownloadAssetBundle(string url, int gameNumber)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            _statusText.text = "Error loading AssetBundle " + gameNumber;
            Debug.LogError("Error loading: " + request.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            if (gameNumber == 1)
            {
                _assetBundle1 = bundle;
                _statusText.text = "AssetBundle 1 loaded";
            }
            else if (gameNumber == 2)
            {
                _assetBundle2 = bundle;
                _statusText.text = "AssetBundle 2 loaded";
            }
            Debug.Log("AssetBundle " + gameNumber + " loaded");
        }
    }
}
