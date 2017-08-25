using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeL : MonoBehaviour {

    void RayCast()
    {
        Debug.DrawRay(new Vector3(transform.position.x,transform.position.y+ 0.5f,transform.position.z), transform.forward * 10, Color.green);
        RaycastHit hit;

        if (Physics.Raycast(new Vector3(0,0,0), transform.forward, out hit, 10f))
        { 
        }
}
}
