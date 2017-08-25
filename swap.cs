using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class swap : MonoBehaviour {

  
	void Start () {
      //  ChangScance changScance =   GetComponent<ChangScance>().MainMenu();
	}
    public void MainMenu()
    {

        SceneManager.LoadScene(1);
    }

}
