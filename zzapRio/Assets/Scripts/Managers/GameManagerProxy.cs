using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerProxy : MonoBehaviour
{
    public UIManager1 uiManager;

    private void Start()
    {
        uiManager.RetryUIAnimation();
    }
}
