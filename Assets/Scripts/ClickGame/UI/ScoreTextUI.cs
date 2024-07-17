using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _clickScoreText;
    [SerializeField] private ScoreController _scoreController;

    private void Update()
    {
        _clickScoreText.text = _scoreController.GetClickScore().ToString();
    }
}
