using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if(null == instance)
            {
                return null;
            }
            else
                return instance;
        }
    }
    private int score = 0;
    private int maxScore = 0;
    public int Score
    {
        get { return score; }
        set { if (score >= maxScore)
            {
                maxScore = score;
            }
            else
            {
                score = value;
            };
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
}
