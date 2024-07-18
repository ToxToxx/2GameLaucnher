using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class AssetManager : MonoBehaviour
{
    // URL до вашего сервера с ассетами (замените на ваш URL)
    private string assetBundleURL1 = "https://storage.yandexcloud.net/unitytestzadanie/clickgamepackedassets_scenes_all_18adbe70653bfdf222ed6a2188404f33.bundle";
    private string assetBundleURL2 = "https://storage.yandexcloud.net/unitytestzadanie/runnergamepackedassets_scenes_all_e5fb86d1632af0f0c9e89f935b224b79.bundle";

    // Кэшированные AssetBundles
    private AssetBundle assetBundle1;
    private AssetBundle assetBundle2;

    // UI элементы
    public Button loadButton1;
    public Button loadButton2;
    public Button unloadButton1;
    public Button unloadButton2;
    public TextMeshProUGUI statusText;

    void Start()
    {
        // Добавляем слушатели к кнопкам
        loadButton1.onClick.AddListener(() => LoadAssetBundle(1));
        loadButton2.onClick.AddListener(() => LoadAssetBundle(2));
        unloadButton1.onClick.AddListener(() => UnloadAssetBundle(1));
        unloadButton2.onClick.AddListener(() => UnloadAssetBundle(2));
    }

    // Метод для загрузки ассета
    public void LoadAssetBundle(int gameNumber)
    {
        if (gameNumber == 1)
        {
            StartCoroutine(DownloadAssetBundle(assetBundleURL1, 1));
        }
        else if (gameNumber == 2)
        {
            StartCoroutine(DownloadAssetBundle(assetBundleURL2, 2));
        }
    }

    // Метод для выгрузки ассета
    public void UnloadAssetBundle(int gameNumber)
    {
        if (gameNumber == 1 && assetBundle1 != null)
        {
            assetBundle1.Unload(true);
            assetBundle1 = null;
            statusText.text = "AssetBundle 1 выгружен";
            Debug.Log("AssetBundle 1 выгружен");
        }
        else if (gameNumber == 2 && assetBundle2 != null)
        {
            assetBundle2.Unload(true);
            assetBundle2 = null;
            statusText.text = "AssetBundle 2 выгружен";
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
            statusText.text = "Ошибка загрузки AssetBundle " + gameNumber;
            Debug.LogError("Ошибка загрузки: " + request.error);
        }
        else
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            if (gameNumber == 1)
            {
                assetBundle1 = bundle;
                statusText.text = "AssetBundle 1 загружен";
            }
            else if (gameNumber == 2)
            {
                assetBundle2 = bundle;
                statusText.text = "AssetBundle 2 загружен";
            }
            Debug.Log("AssetBundle " + gameNumber + " загружен");
        }
    }
}
