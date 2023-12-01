using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subrunker_BulletManager : MonoBehaviour
{
    // Bullet �������� ����, ������ ��ġ�� �����ϵ��� �����ϴ� �Ŵ��� ��ũ��Ʈ
    [SerializeField]
    public Subrunker_Bullet bullet;
    [SerializeField]
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        // ó�� ���� 10���� Bullet ������Ʈ ����
        for (int i = 0; i < 10; i++)
        {
            SpawnBullet();
        }

        // ���� �ڷ�ƾ���� �ֱ������� Bullet ������Ʈ ����
        StartCoroutine(SpawnBulletCoroutine());

        // �Ѿ� ���� �ֱ� ����������
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
        // Bullet ������Ʈ�� ������ ������ �����ϰ� �����ϴ� �Լ�
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
