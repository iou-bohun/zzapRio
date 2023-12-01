using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    [SerializeField]
    public bool isNewRecord = false;
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
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        
    }

    [SerializeField]
    private int score=0;
    public int Score
    {
        get { return score; }
        set
        { 
            score = value;
            if(score > maxScore)
            {
                maxScore = score;   
                isNewRecord = true;
            }
            else
            {
                isNewRecord = false;
            }
        }
    }
    [SerializeField]private int maxScore = 0;
    public int MaxScore
    {
        get { return maxScore; }
    }



}
