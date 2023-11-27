using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNode : MonoBehaviour
{
    Collider2D coll;
    [SerializeField]GameObject node;
    private void Start()
    {
        coll = GetComponent<Collider2D>();
        Spawn_Node();
    }

    /// <summary>
    /// 랜덤 생성위치 리턴하는 함수
    /// </summary>
    /// <returns>SpawnRange사이즈에 해당하는 랜덤위치 Vector3</returns>
    Vector3 ReturnRandomPosition()
    {
        Vector3 originalPosition = transform.position; //원래 Position
        float rangeX = coll.bounds.size.x; // 스폰크기x
        float rangeY = coll.bounds.size.y;// 스폰크기y
        rangeX = Random.Range((rangeX/2)*-1, rangeX/2);//스폰범위x
        rangeY = Random.Range((rangeY/2)*-1, rangeY/2);//스폰범위y
        Vector3 randomPosition = new Vector3(rangeX, rangeY, 0);
        Vector3 spawnPosition = originalPosition + randomPosition;

        return spawnPosition;
    }

    /// <summary>
    /// 노드 생성
    /// </summary>
    void Spawn_Node()
    {
        node = Instantiate(node);
        node.transform.position = ReturnRandomPosition();
    }
}
