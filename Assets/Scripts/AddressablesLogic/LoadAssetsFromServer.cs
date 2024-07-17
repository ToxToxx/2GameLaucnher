using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class LoadAssetsFromServer : MonoBehaviour
{
    [SerializeField] private Button _loadClickGameAssetsButtn;
    [SerializeField] private Button _loadRunnerGameAssetsButtn;
    [SerializeField] private Button _unloadClickGameAssetsButtn;
    [SerializeField] private Button _unloadRunnerGameAssetsButtn;

    private string _scene1URL = "https://github.com/ToxToxx/2GameLaucnher/main/ClickGame1.unity";
    private string _scene2URL = "https://github.com/ToxToxx/2GameLaucnher/main/RunGame2.unity";

    private GameObject _scene1;
    private GameObject _scene2;

    void Start()
    {
        _loadClickGameAssetsButtn.onClick.AddListener(() => StartCoroutine(LoadScene(_scene1URL, 1)));
        _loadRunnerGameAssetsButtn.onClick.AddListener(() => StartCoroutine(LoadScene(_scene2URL, 2)));
        _unloadClickGameAssetsButtn.onClick.AddListener(() => UnloadScene(1));
        _unloadRunnerGameAssetsButtn.onClick.AddListener(() => UnloadScene(2));
    }

    IEnumerator LoadScene(string url, int sceneNumber)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(request);
            string scenePath = bundle.GetAllScenePaths()[0];
            if (sceneNumber == 1)
            {
                _scene1 = Instantiate(bundle.LoadAsset<GameObject>("Scene1"));
            }
            else if (sceneNumber == 2)
            {
                _scene2 = Instantiate(bundle.LoadAsset<GameObject>("Scene2"));
            }
            bundle.Unload(false);
        }
        else
        {
            Debug.LogError("Failed to load scene from URL: " + url);
        }
    }

    void UnloadScene(int sceneNumber)
    {
        if (sceneNumber == 1 && _scene1 != null)
        {
            Destroy(_scene1);
        }
        else if (sceneNumber == 2 && _scene2 != null)
        {
            Destroy(_scene2);
        }
    }
}
