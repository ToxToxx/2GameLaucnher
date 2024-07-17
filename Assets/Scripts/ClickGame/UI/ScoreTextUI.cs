using TMPro;
using UnityEngine;

namespace ClickGame
{
    public class ScoreTextUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _clickScoreText;
        [SerializeField] private ScoreController _scoreController;

        private void Update()
        {
            _clickScoreText.text = _scoreController.GetClickScore().ToString();
        }
    }

}
