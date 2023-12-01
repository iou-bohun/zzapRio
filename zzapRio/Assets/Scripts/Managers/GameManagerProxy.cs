using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerProxy : MonoBehaviour
{
    public void Restart()
    {
        GameManager.Instance.LoadNextScene();
        DataManager.Instance.Score = 0;
    }
}
