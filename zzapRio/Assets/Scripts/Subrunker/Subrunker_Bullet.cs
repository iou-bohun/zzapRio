using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subrunker_Bullet : MonoBehaviour
{
    [SerializeField]
    public float velocity;

    public Vector3 dircVector;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Random.Range(2.5f, 5.0f);

        GameObject plyaer = GameObject.Find("Player");

        if (plyaer != null)
        {
            // Player 오브젝트를 바라보는 방향벡트 구하기
            dircVector = (plyaer.transform.position - transform.position).normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (dircVector * velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            // Player 오브젝트에 충돌했을 때 실행. 충돌시 GameOver 상태로 전환하면 될 듯
            Debug.Log("hit");
        }
    }
}
