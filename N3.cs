using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TanksMP.Controller;
public class N3 : MonoBehaviour {

    public PlayerController playerController;
    public Text T;
    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update () 
    {
        T.text = playerController.hiden.ToString();   
    }
}

