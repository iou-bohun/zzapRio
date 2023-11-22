using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearDrops : MonoBehaviour
{
    private void Update()
    {
        if(this.transform.localPosition.x < -7)
        {
            Destroy(gameObject);
        }
    }
}
