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
    /// ���� ������ġ �����ϴ� �Լ�
    /// </summary>
    /// <returns>SpawnRange����� �ش��ϴ� ������ġ Vector3</returns>
    Vector3 ReturnRandomPosition()
    {
        Vector3 originalPosition = transform.position; //���� Position
        float rangeX = coll.bounds.size.x; // ����ũ��x
        float rangeY = coll.bounds.size.y;// ����ũ��y
        rangeX = Random.Range((rangeX/2)*-1, rangeX/2);//��������x
        rangeY = Random.Range((rangeY/2)*-1, rangeY/2);//��������y
        Vector3 randomPosition = new Vector3(rangeX, rangeY, 0);
        Vector3 spawnPosition = originalPosition + randomPosition;

        return spawnPosition;
    }

    /// <summary>
    /// ��� ����
    /// </summary>
    void Spawn_Node()
    {
        node = Instantiate(node);
        node.transform.position = ReturnRandomPosition();
    }
}
