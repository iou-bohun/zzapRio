using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRacing_Road : MonoBehaviour
{
    // Player ������Ʈ�� �浹 ���� ��ũ��Ʈ
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
        //�浹 ����
        Debug.Log("hit");
        if(!collision.GetComponent<RoadRacing_PlayerMovement>().gameOver)
        {
            Debug.Log("GameOver");
            //PlayerMovement ��ũ��Ʈ�� �ִ� ���� ���� ���� ��ȯ. ���� ������ ���Ӹ޴������� �����ؾ� �Ұ� ���� ��
            collision.GetComponent<RoadRacing_PlayerMovement>().gameOver = true;
            GameManager.Instance.LoadRetryScene();
        }
    }
}
