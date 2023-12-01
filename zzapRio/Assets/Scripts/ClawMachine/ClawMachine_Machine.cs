using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ClawMachine_Machine : MonoBehaviour
{
    GameObject LeftArm;
    GameObject RightArm;
    Transform Spot;

    [SerializeField]
    private bool isGrab = false;
    [SerializeField]
    private bool isDone = false;

    [SerializeField]
    public float speed;

    private bool movingRight = true;

    [SerializeField]
    private bool success = false;

    // Start is called before the first frame update
    void Start()
    {
        //팔 움직임 표현을 위해 팔 게임 오브젝트 가져오기
        LeftArm = transform.Find("Arms/LeftArm").gameObject;
        RightArm = transform.Find("Arms/RightArm").gameObject;

        //인형 뽑기로 인형을 집었을 때 인형을 붙일 Spot 오브젝트 가져오기
        Spot = transform.Find("Spot");

        //스피드 조절
        speed = 3;
        speed += DataManager.Instance.Score / 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            isGrab = true;
        }

        if (!isGrab)
        {
            //인형뽑기 팔 좌우 움직임
            Moving();
        }
        else if(isGrab && !isDone)
        {
            //인형뽑기 팔 아래로 내래기, 인형 집기 움직임 표현
            Grab();
        }
        else if (isDone)
        {
            //인형 집기 움직임이 끝난 후 원래 자리로 올리기
            Raise();
        }
    }

    void Moving()
    {
        if (movingRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);

            if(transform.position.x > 2.6f)
                movingRight = false;
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if(transform.position.x < -0.6f)
                movingRight = true;
        }
    }

    void Grab()
    {
        //Hand Move Down and Grab Doll
        if(transform.position.y > -3.9)
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        else
        {
            if (LeftArm.transform.rotation.eulerAngles.z < 40.0f)
            {
                LeftArm.transform.RotateAround(LeftArm.transform.position, Vector3.back, -20 * Time.deltaTime);
                RightArm.transform.RotateAround(RightArm.transform.position, Vector3.back, 20 * Time.deltaTime);
            }
            else
                isDone = true;
        }
    }

    void Raise()
    {
        if (transform.position.y < 5)
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        //팔이 다 올라가고 난 후 Spot 오브젝트 자식에 인형이 있는지 없는지로 게임 성공, 실패 여부 확인하면 될 듯

        if(transform.position.y > 5)
        {
            if(success == true)
            {
                GameManager.Instance.LoadNextScene();
                DataManager.Instance.Score++;
            }
            else
            {
                GameManager.Instance.LoadRetryScene();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //인형 집기 움직임이 끝났을 때 인형 콜라이더와 겹쳐있을 때 인형 오브젝트를 Spot의 자식으로 넣음
        if (isDone)
        {
            if (collision != null && collision.transform.name == "Doll")
            {
                collision.transform.parent = Spot;
                success = true;
            }
        }
    }
}
