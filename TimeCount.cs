//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.SceneManagement;
//
//public class TimeCount : MonoBehaviour 
//{
//
//
//    Image fillImg;
//    float timeAmt = 15;
//    float time;
//    public Text timeText;
//
//    public GameObject timer;
//
//
//	void Start ()
//    {
//        timer.gameObject.SetActive(false);
//        
//        fillImg = this.GetComponent<Image>();
//        time = timeAmt;
//		
//	}
//	void Update () 
//    {
//        if (time >= 0)
//        {
//            time -= Time.deltaTime;
//            fillImg.fillAmount = time / timeAmt;
//            timeText.text = "" + time.ToString("F"); // patterns for HH:mm:ss
//        }
//
//        if (time <= 0)
//        {
//
//            SceneManager.LoadScene(2);
//        }
//		
//	}
//}
