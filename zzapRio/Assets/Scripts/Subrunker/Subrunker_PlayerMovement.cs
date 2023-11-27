using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subrunker_PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public Vector3 position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;
    }

}