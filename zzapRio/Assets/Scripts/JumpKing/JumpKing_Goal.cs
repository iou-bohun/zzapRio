using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKing_Goal : MonoBehaviour
{
    [SerializeField] float rotationSpeed; // 회전 속도
    private void Update()
    {
        rotationSpeed = Mathf.PingPong(Time.time*5f, 1.5f) + 0.5f; // 0.5 ~ 2.5까지 반복해서 값을가지는 속도
        transform.Rotate(new Vector3(0, 0, rotationSpeed));// 회전
    }
}
