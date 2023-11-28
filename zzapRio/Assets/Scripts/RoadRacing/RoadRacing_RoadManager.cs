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
        // road 오브젝트 위치 조정
        roads.transform.position = startPos;

        // 현제 Road 오브젝트가 다 내려온 후 다음 오브젝트를 이어 붙여 내려주기 위해 현재, 다음 Road 오브젝트 저장.
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
            // Road 오브젝트를 끝지점까지 내리면 다음 Road 오브젝트를 이어 내려주기
            currentRoad = nextRoad;
            currentRoad.transform.position = startPos;
        }
    }
}
