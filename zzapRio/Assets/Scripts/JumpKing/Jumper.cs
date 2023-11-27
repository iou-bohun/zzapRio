using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] float jumpForce; // 점프 힘 조절
    private float clickTime; // 마우스 클릭한  시점
    public bool isJumping = false; // 점프 중인지 여부
    private bool isReady = false; // 웅크리는지 여부 
    [SerializeField] float minJumpForce = 5f; // 최소 점프 
    [SerializeField] float maxJumpForce = 15f; // 최대 점프
    [SerializeField] float dirForce = 150;// 좌우 이동 최소
    public static float Force; //점프, 이동 힘 합한수치


    Rigidbody2D rb;
    Renderer render;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<Renderer>();
    }
    void Update()
    {
        // 마우스 왼쪽 버튼이 클릭되었을 때
        if (Input.GetMouseButtonDown(0) && !isJumping)
        {
            clickTime = Time.time; // 클릭한 시간 기록
            isReady = true;

            render.material.color = Color.yellow;//클릭시 색 변경 
        }

        // 마우스 왼쪽 버튼이 떼어졌을 때
        if (Input.GetMouseButtonUp(0) && isReady && !isJumping)
        {
            float jumpDuration = Time.time - clickTime; // 클릭한 시간 계산
            float dir = Input.GetAxisRaw("Horizontal");// 나아가는 방향 계산

            // 점프 함수 호출 및 클릭한 시간을 기반으로 힘 조절
            Jump(jumpDuration, dir);
            render.material.color = Color.white;//원래 색으로 변경
        }
    }

    /// <summary>
    /// 플레이어 점프
    /// </summary>
    /// <param name="jumpDuration">클릭한 시간 </param>
    /// <param name="dir">점프하는 방향 </param>
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

        //최대 점프 크기 
        else if(calculatedJumpForce >maxJumpForce)
        {
            calculatedJumpForce = maxJumpForce;
        }

        //좌우 점프 힘 
        float calculatedDirForce = dir * dirForce;

        Force = calculatedDirForce * calculatedJumpForce;// 종합 힘 

        // 캐릭터에게 힘을 가하고 점프
        rb.AddForce(Vector3.up * calculatedJumpForce,ForceMode2D.Impulse);
        rb.AddForce(Vector3.right *calculatedDirForce);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")//지면과 충돌시 
        {
            //점프킹 움직임 멈추기
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;

            //변수들 초기화 
            isJumping = false;
            isReady = false;
        }
    }

    /// <summary>
    /// 클리어 조건
    /// </summary>
    /// <param name="goal">골 오브젝트</param>
    private void OnTriggerEnter2D(Collider2D goal)
    {
        if (goal.gameObject.tag == "Goal")
        {
            //골에 도착했을때 
            DataManager.Instance.Score++;
            GameManager.Instance.LoadNextScene();
        }
    }
}
