using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ChangScance : MonoBehaviour 
{
    public  int Save;
    public Text NumberText;
    public Slider slider;
    public GameObject Loadingscene;
    public GameObject[] Image;
	void Start () 
    {
        Save = PlayerPrefs.GetInt("Save");
     
	}
    void Update()
    {
      
        if (Save >= 1) // state 2
        {
          
            Image[0].SetActive(false);
        }
        else
        {
            
            Image[0].SetActive(true);
        }
        if(Save >=2)
        {
           
            Image[1].SetActive(false);
        }
        else
        {
            
            Image[1].SetActive(true);
        }
        if(Save >=3)
        {
           
            Image[2].SetActive(false);
        }
        else
        {
         
            Image[2].SetActive(true);
        }

    }
 



    public void ALLState()
    {
        SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
                
        SceneManager.LoadScene(0);
    }

    public void Victory()
    {
//        SceneManager.LoadScene(4);
    }

    public void SelectionSence()
    {
        SceneManager.LoadScene(3);
    }

    public void State1(int sceneIndex)
    {
        if (Save >= 0)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
           // SceneManager.LoadScene(2);
        }
    }

    public void State2(int sceneIndex)
    {
       // Debug.Log(a);
        if (Save >= 1)
        {
            //Debug.Log(a);
            StartCoroutine(LoadAsynchronously(sceneIndex));
            //SceneManager.LoadScene(3);
        }
    }
    public void State3(int sceneIndex)
    {
        
        if (Save >= 2)
        {
           // Debug.Log(a);
            StartCoroutine(LoadAsynchronously(sceneIndex));
            //SceneManager.LoadScene(4);
        }
    }
    public void State4(int sceneIndex)
    {
        if (Save >= 3)
                {
       // Debug.Log(a);
        StartCoroutine(LoadAsynchronously(sceneIndex));
        //SceneManager.LoadScene(5);
                }
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        Loadingscene.SetActive(true);

        while (!operation.isDone)
        {
            float number = Mathf.Clamp01(operation.progress / .9f);
            slider.value = number;
            NumberText.text = number * 100f + "%";
            yield return null;
        }
    }
    public void HardGame(int sceneIndex)
    {
        if (Save >= 1)
        {
            StartCoroutine(LoadAsynchronously(sceneIndex));
        }
    }
}
