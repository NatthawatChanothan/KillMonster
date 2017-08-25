using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScripEnd2 : MonoBehaviour 
{
    public int a;
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            a = 2;
        
            if (PlayerPrefs.GetInt("Save") == 1)
            {
                
                PlayerPrefs.SetInt("Save", a);
            }
            SceneManager.LoadScene(6);

        }

    }
}
