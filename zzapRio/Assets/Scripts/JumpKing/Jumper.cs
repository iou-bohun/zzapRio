using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float jumpForce; // ���� �� ����
    private float clickTime; // ���콺 Ŭ����  ����
    public bool isJumping = false; // ���� ������ ����
    private bool isReady = false; // ��ũ������ ���� 
    [SerializeField] float minJumpForce = 5f; // �ּ� ���� 
    [SerializeField] float maxJumpForce = 15f; // �ִ� ����
    [SerializeField] float dirForce = 150;// �¿� �̵� �ּ�
    public static float Force; //����, �̵� �� ���Ѽ�ġ


    Rigidbody2D rb;
    Renderer render;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
    }
    void Update()
    {
        // ���콺 ���� ��ư�� Ŭ���Ǿ��� ��
        if (Input.GetMouseButtonDown(0) && !isJumping)
        {
            clickTime = Time.time; // Ŭ���� �ð� ���
            isReady = true;

            render.material.color = Color.yellow;//Ŭ���� �� ���� 
        }

        // ���콺 ���� ��ư�� �������� ��
        if (Input.GetMouseButtonUp(0) && isReady && !isJumping)
        {
            float jumpDuration = Time.time - clickTime; // Ŭ���� �ð� ���
            float dir = Input.GetAxisRaw("Horizontal");// ���ư��� ���� ���

            // ���� �Լ� ȣ�� �� Ŭ���� �ð��� ������� �� ����
            Jump(jumpDuration, dir);
            render.material.color = Color.white;//���� ������ ����
        }
    }

    /// <summary>
    /// �÷��̾� ����
    /// </summary>
    /// <param name="jumpDuration">Ŭ���� �ð� </param>
    /// <param name="dir">�����ϴ� ���� </param>
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

        //�ִ� ���� ũ�� 
        else if(calculatedJumpForce >maxJumpForce)
        {
            calculatedJumpForce = maxJumpForce;
        }

        //�¿� ���� �� 
        float calculatedDirForce = dir * dirForce;

        Force = calculatedDirForce * calculatedJumpForce;// ���� �� 

        // ĳ���Ϳ��� ���� ���ϰ� ����
        rb.AddForce(Vector3.up * calculatedJumpForce,ForceMode2D.Impulse);
        rb.AddForce(Vector3.right *calculatedDirForce);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//����� �浹�� 
        {
            //����ŷ ������ ���߱�
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            //������ �ʱ�ȭ 
            isJumping = false;
            isReady = false;
        }
    }

    /// <summary>
    /// Ŭ���� ����
    /// </summary>
    /// <param name="goal">�� ������Ʈ</param>
    private void OnTriggerEnter2D(Collider2D goal)
    {
        if (goal.gameObject.tag == "Goal")
        {
            //�� ���������� 
            DataManager.Instance.Score++;
            GameManager.Instance.LoadNextScene();
        }
    }
}
