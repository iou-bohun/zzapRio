using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRacing_RoadManager : MonoBehaviour
{
    [SerializeField]
    public GameObject roads;
    public float speed;

    public Vector3 startPos;
    public Vector3 endPos;

    public GameObject currentRoad;
    public GameObject nextRoad;

    // Start is called before the first frame update
    void Start()
    {
        roads.transform.position = startPos;
        currentRoad = roads;
        nextRoad = roads;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentRoad.transform.position.y > endPos.y)
        {
            currentRoad.transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            currentRoad = nextRoad;
            currentRoad.transform.position = startPos;
        }
    }
}
