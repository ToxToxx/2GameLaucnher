using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/// <summary>
/// ����� �������, �� ������� ������ �����
/// </summary>
public class CurrentTimeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentTimeText;

    private void Update()
    {
        _currentTimeText.text = "Time: " + TimeController.Instance.GetCurrentTime().ToString("F2");
    }
}


