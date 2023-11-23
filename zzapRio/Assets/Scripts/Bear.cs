using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool isGood  = false; // 맥주가 PerfectZone에 도달 했는지
    [SerializeField] GameObject[] bears;
    private void Update()
    {
        BearMove();
        FillBear();
        FailCheck();
        Debug.Log(isGood);
    }

    void BearMove()
    {
        //마우스 클릭하는 동안 
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed); //맥주 위로 이동
        }

        //마우스 클릭떼는 순간 
        if (Input.GetMouseButtonUp(0))
        {
            if (isGood)
            {
                //성공
                Debug.Log("Win");
            }
            else
            {
                // 실패 
                Debug.Log("Fail");
            }
        }
    }

    //맥주잔 체우기 
    void FillBear()
    {
        //맥주 위치에 따라 맥주 이미지 생성
        if(this.transform.localPosition.y >= bears[0].transform.localPosition.y)
        {
            bears[0].SetActive(true);
        }
        if(this.transform.localPosition.y >= bears[1].transform.localPosition.y)
        {
            bears[1].SetActive(true);
        }
        if(this.transform.localPosition.y >= bears[2].transform.localPosition.y)
        {
            bears[2].SetActive(true);
        }
    }

    void FailCheck()
    {
        //맥주잔을 넘어갈 경우
        if(this.transform.localPosition.x > 0.4)
        {
            //실패
            Debug.Log("Fail");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PerfectZone")
        {
            isGood = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PerfectZone")
        {
            isGood = false;
        }
    }
}
