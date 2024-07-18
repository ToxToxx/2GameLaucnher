using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// класс хранящий сцены в проекте и их загрузку
/// </summary>
public static class Loader
{
    public enum Scene
    {
        Launcher,
        LoadingScreen,
        ClickGame1,
        RunGame2,
    }

    private static Scene _targetScene;

    public static void Load(Scene targetScene)
    {
        _targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(_targetScene.ToString());
    }
}
