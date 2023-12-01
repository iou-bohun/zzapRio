using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Node : MonoBehaviour
{
    public static KeyCode randomKey;
    [SerializeField] TextMeshProUGUI keyText;
    private KeyCode[] codes = new[]
    {
        KeyCode.Q,
        KeyCode.W,
        KeyCode.E,
        KeyCode.R
    };

    private void Awake()
    {
        randomKey = RandomKey();
        keyText.text = randomKey.ToString();
    }

    private KeyCode RandomKey()
    {
        int codeNum;
        codeNum = Random.Range(0, codes.Length);
        return codes[codeNum];  
    }
}
