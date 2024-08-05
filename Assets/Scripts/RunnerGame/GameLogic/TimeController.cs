using UnityEngine;

/// <summary>
/// Time controller that tracks and records the time taken by the player.
/// </summary>
public class TimeController : MonoBehaviour
{
    public static TimeController Instance;

    private float _currentTime;
    private float _bestTime;
    private bool _isGameRunning;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        _bestTime = PlayerPrefs.GetFloat("BestTime", float.MaxValue);
        ResetTimer();
        StartTimer();
    }

    private void Update()
    {
        if (_isGameRunning)
        {
            _currentTime += Time.deltaTime;
        }
    }

    private void StartTimer()
    {
        _isGameRunning = true;
    }

    public void StopTimer()
    {
        _isGameRunning = false;
        if (_currentTime < _bestTime)
        {
            Time.timeScale = 0f;
            _bestTime = _currentTime;
            PlayerPrefs.SetFloat("BestTime", _bestTime);
        }
    }

    private void ResetTimer()
    {
        _currentTime = 0f;
        _isGameRunning = false;
    }

    public float GetCurrentTime()
    {
        return _currentTime;
    }
    public float GetBestTime()
    {
        return _bestTime;
    }
}

