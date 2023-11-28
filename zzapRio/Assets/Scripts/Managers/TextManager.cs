using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI score;

    private void Update()
    {
        score.text = DataManager.Instance.Score.ToString();
    }
}
