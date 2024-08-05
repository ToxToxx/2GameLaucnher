using UnityEngine.SceneManagement;

/// <summary>
/// Class that manages the scenes in the project and their loading.
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

    /// <summary>
    /// Initiates loading of the specified target scene, starting with the loading screen.
    /// </summary>
    /// <param name="targetScene">The scene to be loaded after the loading screen.</param>
    public static void Load(Scene targetScene)
    {
        _targetScene = targetScene;
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());
    }

    /// <summary>
    /// Callback method to be called after the loading screen has completed loading, 
    /// to load the target scene.
    /// </summary>
    public static void LoaderCallback()
    {
        SceneManager.LoadScene(_targetScene.ToString());
    }
}
