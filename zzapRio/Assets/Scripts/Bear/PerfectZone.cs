using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectZone : MonoBehaviour
{
    BoxCollider2D coll;
   [SerializeField] GameObject perfectZone;
    private void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        SpawnPerfectZone();
    }

    Vector3 getSpawnPoint()
    {
        Vector3 originPosition = transform.position;
        float spawnSizeY = coll.bounds.size.y;
        Debug.Log(spawnSizeY);
        float randomY = Random.Range((spawnSizeY / 2) * -1, spawnSizeY / 2);

        Vector3 spawn = new Vector3(0, randomY, 0);
        Vector3 spawnPoint = spawn + originPosition;
        return spawnPoint;
    }

    void SpawnPerfectZone()
    {
        Instantiate(perfectZone);
        perfectZone.transform.position = getSpawnPoint();
        
    }
}
