using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subrunker_Bullet : MonoBehaviour
{
    [SerializeField]
    public float velocity;

    public Vector3 dircVector;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Random.Range(2.5f, 5.0f);

        GameObject plyaer = GameObject.Find("Player");

        if (plyaer != null)
        {
            dircVector = (plyaer.transform.position - transform.position).normalized;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (dircVector * velocity * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("hit");
        }
    }
}
