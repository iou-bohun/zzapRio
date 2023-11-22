using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool isGood  = false; // ���ְ� PerfectZone�� ���� �ߴ���
    private void Update()
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
                Debug.Log("Win");
            }
            else
            {
                Debug.Log("Fail");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGood = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGood = false;
    }
}
