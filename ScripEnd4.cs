using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScripEnd4 : MonoBehaviour 
{
    public int a;
    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            a = 4;
      
            if (PlayerPrefs.GetInt("Save") == 3)
            {

                PlayerPrefs.SetInt("Save", a);
            }
            SceneManager.LoadScene(6);

        }

    }
}
