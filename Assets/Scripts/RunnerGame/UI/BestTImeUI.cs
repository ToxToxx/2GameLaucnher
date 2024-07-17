using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestTImeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestTimeText;

    private void Update()
    {
        _bestTimeText.text = "Best Time: " + (TimeController.Instance.GetBestTime() == float.MaxValue ? "N/A" : TimeController.Instance.GetBestTime().ToString("F2"));
    }
}
