using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpKing_Goal : MonoBehaviour
{
    [SerializeField] float rotationSpeed; // ȸ�� �ӵ�
    private void Update()
    {
        rotationSpeed = Mathf.PingPong(Time.time*5f, 1.5f) + 0.5f; // 0.5 ~ 2.5���� �ݺ��ؼ� ���������� �ӵ�
        transform.Rotate(new Vector3(0, 0, rotationSpeed));// ȸ��
    }
}
