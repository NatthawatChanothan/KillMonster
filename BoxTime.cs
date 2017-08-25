using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTime : MonoBehaviour {

    public GameObject CdTime;
	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            CdTime.gameObject.SetActive(true);
        }
            
    }

       
}
