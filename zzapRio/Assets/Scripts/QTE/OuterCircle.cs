using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.U2D;
using UnityEngine;

public class OuterCircle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool isPerfect;

    
    private void Update()
    {

        Debug.Log(isPerfect);
        UpdateSacle();
        if (Input.GetKeyDown(Node.randomKey))
        {
            if (isPerfect)
            {
                //성공시
                DataManager.Instance.Score++;
                GameManager.Instance.LoadNextScene();
            }
            else
            {
                //실패시
                GameManager.Instance.LoadRetryScene();
            }
        }
    }

    //점점 크기 작아지게
    void UpdateSacle()
    {
        transform.localScale = new Vector3(transform.localScale.x - 1f * speed * Time.deltaTime,
            transform.localScale.y - 1f * speed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPerfect = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isPerfect = false;
    }
}
