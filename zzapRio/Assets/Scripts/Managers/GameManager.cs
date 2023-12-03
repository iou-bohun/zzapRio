using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            else
                return instance;
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

    public void LoadRetryScene()
    {
        SceneManager.LoadScene("retry");
    }

    public void LoadNextScene()
    {
        //다음 게임 랜덤 로드
        SceneManager.LoadScene(Random.Range(2,SceneManager.sceneCountInBuildSettings)); //0 씬은 메인화면 1 씬은 Retry
       
    }

    IEnumerator SceneDelay()
    {
        yield return new WaitForSeconds(1f);
    }
}
