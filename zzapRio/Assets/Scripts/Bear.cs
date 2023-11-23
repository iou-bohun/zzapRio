using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool isGood  = false; // ���ְ� PerfectZone�� ���� �ߴ���
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
        //���콺 Ŭ���ϴ� ���� 
        if (Input.GetMouseButton(0))
        {
            transform.Translate(Vector2.up * Time.deltaTime * moveSpeed); //���� ���� �̵�
        }

        //���콺 Ŭ������ ���� 
        if (Input.GetMouseButtonUp(0))
        {
            if (isGood)
            {
                //����
                Debug.Log("Win");
            }
            else
            {
                // ���� 
                Debug.Log("Fail");
            }
        }
    }

    //������ ü��� 
    void FillBear()
    {
        //���� ��ġ�� ���� ���� �̹��� ����
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
        //�������� �Ѿ ���
        if(this.transform.localPosition.x > 0.4)
        {
            //����
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
