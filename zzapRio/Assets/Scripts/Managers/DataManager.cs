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

    private int score=0;
    public int Score
    {
        get { return score; }
        set
        { 
            score = value;
        if(score> MaxScore ) 
                score = MaxScore; 
        }
    }
    private int maxScore;
    public int MaxScore
    {
        get { return maxScore; }
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
