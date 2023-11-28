using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subrunker_DrawGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Bullet 오브젝트가 화면 밖으로 벗어나 벽에 부딪힐 시 해당 오브젝트 파괴
        Destroy(collision.gameObject);
    }
}
