using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] float pushForce;
    private void OnCollisionEnter2D(Collision2D collision)
    {
       Vector2 collisionDirection = collision.contacts[0].point - (Vector2)transform.position;
       collisionDirection = collisionDirection.normalized;
       Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
       // �ݴ� �������� ���� ���ϸ鼭 ��ü�� �о
       rigid.AddForce(Vector2.right*Jumper.Force*pushForce);
        Debug.Log(Jumper.Force);
    }
}
