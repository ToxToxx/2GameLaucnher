using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

/// <summary>
/// Здесь происходит загрузка и выгрузка бандлов адрессаблс в данном случае - сцен с игрой
/// </summary>
public class AssetManager : MonoBehaviour
{
    // URL сервера
    private readonly string _assetBundleURL1 = "https://storage.yandexcloud.net/unitytestzadanie/clickgamepackedassets_scenes_all_18adbe70653bfdf222ed6a2188404f33.bundle";
    private readonly string _assetBundleURL2 = "https://storage.yandexcloud.net/unitytestzadanie/runnergamepackedassets_scenes_all_e5fb86d1632af0f0c9e89f935b224b79.bundle";

    // Кэшированные AssetBundles
    private AssetBundle _assetBundle1;
    private AssetBundle _assetBundle2;

    // UI элементы
    [SerializeField] private Button _loadButton1;
    [SerializeField] private Button _loadButton2;
    [SerializeField] private Button _unloadButton1;
    [SerializeField] private Button _unloadButton2;
    [SerializeField] private TextMeshProUGUI _statusText;

    void Start()
    {
        // Добавляем слушатели к кнопкам
        _loadButton1.onClick.AddListener(() => LoadAssetBundle(1));
        _loadButton2.onClick.AddListener(() => LoadAssetBundle(2));
        _unloadButton1.onClick.AddListener(() => UnloadAssetBundle(1));
        _unloadButton2.onClick.AddListener(() => UnloadAssetBundle(2));
    }

    // Метод для загрузки ассета
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

    // Метод для выгрузки ассета
    private void UnloadAssetBundle(int gameNumber)
    {
        if (gameNumber == 1 && _assetBundle1 != null)
        {
            _assetBundle1.Unload(true);
            _assetBundle1 = null;
            _statusText.text = "AssetBundle 1 выгружен";
            Debug.Log("AssetBundle 1 выгружен");
        }
        else if (gameNumber == 2 && _assetBundle2 != null)
        {
            _assetBundle2.Unload(true);
            _assetBundle2 = null;
            _statusText.text = "AssetBundle 2 выгружен";
            Debug.Log("AssetBundle 2 выгружен");
        }
    }

    // Метод для загрузки ассетбандла
    private IEnumerator DownloadAssetBundle(string url, int gameNumber)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            _statusText.text = "Ошибка загрузки AssetBundle " + gameNumber;
            Debug.LogError("Ошибка загрузки: " + request.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            if (gameNumber == 1)
            {
                _assetBundle1 = bundle;
                _statusText.text = "AssetBundle 1 загружен";
            }
            else if (gameNumber == 2)
            {
                _assetBundle2 = bundle;
                _statusText.text = "AssetBundle 2 загружен";
            }
            Debug.Log("AssetBundle " + gameNumber + " загружен");
        }
    }
}
