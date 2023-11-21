using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float jumpForce; // 점프 힘 조절
    private float clickTime; // 마우스 클릭한  시점
    public bool isJumping = false; // 점프 중인지 여부
    private bool isReady = false; // 웅크리는지 여부 
    private float minJumpForce = 5f;

    Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(0) && !isJumping)
        {
            clickTime = Time.time; // 클릭한 시간 기록
            isReady = true;
        }

        // 마우스 왼쪽 버튼이 떼어졌을 때
        if (Input.GetMouseButtonUp(0) && isReady && !isJumping)
        {
            float jumpDuration = Time.time - clickTime; // 클릭한 시간 계산
            float dir = Input.GetAxisRaw("Horizontal");// 나아가는 방향 계산

            // 점프 함수 호출 및 클릭한 시간을 기반으로 힘 조절
            Jump(jumpDuration, dir);
        }
    }

    void Jump(float jumpDuration, float dir)
    {
        isJumping = true;

        // 클릭 시간과 점프크기 곲
        float calculatedJumpForce = jumpForce * jumpDuration;
        // 최소 점프 크기
        if (calculatedJumpForce < minJumpForce)
        {
            calculatedJumpForce = minJumpForce;
        }
        float calculatedDirForce = dir * 100;

        // 캐릭터에게 힘을 가하고 점프
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
