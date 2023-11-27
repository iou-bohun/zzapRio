using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subrunker_BulletManager : MonoBehaviour
{
    [SerializeField]
    public Subrunker_Bullet bullet;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            SpawnBullet();
        }
        StartCoroutine(SpawnBulletCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnBullet()
    {
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
            yield return new WaitForSeconds(0.2f);
            SpawnBullet();
        }
    }
}
