using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subrunker_BulletManager : MonoBehaviour
{
    // Bullet 프리팹을 관리, 랜덤한 위치에 생성하도록 조정하는 매니저 스크립트
    [SerializeField]
    public Subrunker_Bullet bullet;
    [SerializeField]
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        // 처음 시작 10개의 Bullet 오브젝트 생성
        for (int i = 0; i < 10; i++)
        {
            SpawnBullet();
        }

        // 이후 코루틴으로 주기적으로 Bullet 오브젝트 생성
        StartCoroutine(SpawnBulletCoroutine());

        // 총알 생성 주기 레벨디자인
        spawnTime = 0.5f;
        spawnTime -= (DataManager.Instance.Score / 10)*0.1f;
        if (spawnTime < 0.1f)
        {
            spawnTime = 0.1f;
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnBullet()
    {
        // Bullet 오브젝트를 지정된 범위에 랜덤하게 생성하는 함수
        float switchValue = Random.value;
        float xValue = Random.Range(-3.5f, 3.5f);
        float yValue = Random.Range(-5.7f, 5.7f);

        if (switchValue > 0.5f)
        {
            if (Random.value > 0.5f)
            {
                Instantiate(bullet, new Vector3(-3.5f, yValue, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(bullet, new Vector3(3.5f, yValue, 0f), Quaternion.identity);
            }
        }
        else
        {
            if (Random.value > 0.5f)
            {
                Instantiate(bullet, new Vector3(xValue, -5.7f, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(bullet, new Vector3(xValue, 5.7f, 0f), Quaternion.identity);
            }
        }
    }

    IEnumerator SpawnBulletCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnBullet();
        }
    }
}
