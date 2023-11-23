using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class OuterCircle : MonoBehaviour
{
    [SerializeField] float speed;
    private void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x - 1f * speed * Time.deltaTime, 
            transform.localScale.y - 1f * speed * Time.deltaTime, 0);
    }
}
