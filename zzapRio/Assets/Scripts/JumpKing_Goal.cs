using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class JumpKing_Goal : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    private void Update()
    {
        rotationSpeed = Mathf.PingPong(Time.time*5f, 2f) + 0.5f;
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }
}
