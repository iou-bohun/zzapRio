using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRacing_Road : MonoBehaviour
{
    // Player 오브젝트와 충돌 감시 스크립트
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //충돌 감지
        Debug.Log("hit");
        if(!collision.GetComponent<RoadRacing_PlayerMovement>().gameOver)
        {
            Debug.Log("GameOver");
            //PlayerMovement 스크립트에 있는 게임 오버 상태 전환. 게임 오버는 게임메니저에서 관리해야 할거 같긴 함
            collision.GetComponent<RoadRacing_PlayerMovement>().gameOver = true;
            GameManager.Instance.LoadRetryScene();
        }
    }
}
