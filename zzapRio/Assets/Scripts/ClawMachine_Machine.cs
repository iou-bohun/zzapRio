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

    // Start is called before the first frame update
    void Start()
    {
        LeftArm = transform.Find("Arms/LeftArm").gameObject;
        RightArm = transform.Find("Arms/RightArm").gameObject;
        Spot = transform.Find("Spot");
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
            Moving();
        }
        else if(isGrab && !isDone)
        {
            Grab();
        }
        else if (isDone)
        {
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
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isDone)
        {
            if (collision != null && collision.transform.name == "Doll")
            {
                collision.transform.parent = Spot;
            }
        }
    }
}
