using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    float timer = 5f;

    private void Update()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer);

        if(timer < 0)
        {
            GameManager.Instance.LoadNextScene();
        }
    }
}
