using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearBottle : MonoBehaviour
{
    [SerializeField]GameObject bear;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnInterval;
    [SerializeField] bool flag =true; // 맥주 생성 가능한지
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 130);
            SpawnBear();
        }
        if(Input.GetMouseButtonUp(0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 57);
        }
    }

    void SpawnBear()
    {
        if(flag == false) { return; }
        Instantiate(bear, spawnPoint);
        StartCoroutine("ResetInterval");
    }
    private IEnumerator ResetInterval()
    {
        flag = false;
        yield return new WaitForSeconds(spawnInterval);
        flag = true;
    }
}
