using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float jumpForce; // ���� �� ����
    private float clickTime; // ���콺 Ŭ����  ����
    public bool isJumping = false; // ���� ������ ����
    private bool isReady = false; // ��ũ������ ���� 
    private float minJumpForce = 5f;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���Ǿ��� ��
        if (Input.GetMouseButtonDown(0) && !isJumping)
        {
            clickTime = Time.time; // Ŭ���� �ð� ���
            isReady = true;
        }

        // ���콺 ���� ��ư�� �������� ��
        if (Input.GetMouseButtonUp(0) && isReady && !isJumping)
        {
            float jumpDuration = Time.time - clickTime; // Ŭ���� �ð� ���
            float dir = Input.GetAxisRaw("Horizontal");// ���ư��� ���� ���

            // ���� �Լ� ȣ�� �� Ŭ���� �ð��� ������� �� ����
            Jump(jumpDuration, dir);
        }
    }

    void Jump(float jumpDuration, float dir)
    {
        isJumping = true;

        // Ŭ�� �ð��� ����ũ�� ��
        float calculatedJumpForce = jumpForce * jumpDuration;
        // �ּ� ���� ũ��
        if (calculatedJumpForce < minJumpForce)
        {
            calculatedJumpForce = minJumpForce;
        }
        float calculatedDirForce = dir * 100;

        // ĳ���Ϳ��� ���� ���ϰ� ����
        rb.AddForce(Vector3.up * calculatedJumpForce,ForceMode2D.Impulse);
        rb.AddForce(Vector3.right *calculatedDirForce);

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            isJumping=false;
            isReady = false;
        }
    }
}
