using UnityEngine;
using UnityEngine.UI;

namespace ClickGame
{
    /// <summary>
    /// Controller that manages the player's score. Since the game is small, a single controller is sufficient to add and load the score.
    /// </summary>
    public class ScoreController : MonoBehaviour
    {
        private const string CLICK_COUNT_SCORE = "ClickCountScore";

        [SerializeField] private Button _clickButton;

        private int _clickCountScore;

        private void Start()
        {
            _clickCountScore = PlayerPrefs.GetInt(CLICK_COUNT_SCORE, 0);
            _clickButton.onClick.AddListener(AddClickScore);
        }

        private void AddClickScore()
        {
            _clickCountScore++;
            PlayerPrefs.SetInt(CLICK_COUNT_SCORE, _clickCountScore);
        }

        private void OnApplicationQuit()
        {
            PlayerPrefs.SetInt(CLICK_COUNT_SCORE, _clickCountScore);
        }

        public int GetClickScore()
        {
            return _clickCountScore;
        }
    }
}
