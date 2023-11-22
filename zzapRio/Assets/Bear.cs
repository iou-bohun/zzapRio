using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bear : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] bool isGood  = false; // 맥주가 PerfectZone에 도달 했는지
    private void Update()
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
