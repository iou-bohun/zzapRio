using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadRacing_PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.y = -4.4f;
            mousePosition.z = 0;
            transform.position = mousePosition;
        }
    }
}
