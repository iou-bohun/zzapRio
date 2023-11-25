using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawMachine_Machine : MonoBehaviour
{
    GameObject LeftArm;
    GameObject RightArm;
    // Start is called before the first frame update
    void Start()
    {
        LeftArm = transform.Find("Arms/LeftArm").gameObject;
        RightArm = transform.Find("Arms/RightArm").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(LeftArm.transform.rotation.eulerAngles.z < 40.0f)
            LeftArm.transform.RotateAround(LeftArm.transform.position, Vector3.back, - 20 * Time.deltaTime);
        if (RightArm.transform.rotation.eulerAngles.z < 40.0f)
            RightArm.transform.RotateAround(RightArm.transform.position, Vector3.back, 20 * Time.deltaTime);
    }
}
