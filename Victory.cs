using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Victory : MonoBehaviour {

    public int C;
    public Text textV;
    private int Save;
   
	// Use this for initialization
	void Start () 
    {

        PlayerPrefs.SetInt("coin", C);
        Save = PlayerPrefs.GetInt("Save");
        if (Save == 1)
        {
            textV.text = 400 + "$";
            C += 400;
            PlayerPrefs.SetInt("coin", C);
        }
        if (Save == 2)
        {
            textV.text = 800 + "$";
            C += 800;
            PlayerPrefs.SetInt("coin", C);
        }
        if (Save == 3)
        {
            textV.text = 1200 + "$";
            C += 1200;
            PlayerPrefs.SetInt("coin", C);
        }
        if (Save == 4)
        {
            textV.text = 1400 + "$";
            C += 1400;
            PlayerPrefs.SetInt("coin", C);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
