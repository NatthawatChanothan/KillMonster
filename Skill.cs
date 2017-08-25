//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using TanksMP.Model;
//using TanksMP.View;
//public class Skill : MonoBehaviour 
//{
//
//    public PlayerModel model;
//    public PlayerView view;
//    public float time;
//    public float maxTime = 10;
//    public bool Check = false;
//    public float timecd
//    {
//        get
//        {
//            return time;
//        }
//        set
//        {
//            time = value;
//            if (time <= 0)
//            {
//                time = maxTime;
//            }
//
//        }
//    }
//	// Use this for initialization
//	void Start () {
//		
//	}
//	
//	// Update is called once per frame
//	void Update () 
//    {
//        if(Input.GetKeyDown(KeyCode.X))
//            {
//                ItemHp();
//            }
//        if (Input.GetKeyDown(KeyCode.C))
//        {
//            StrHit();
//        }
//        if (Check == true)
//        {
//            TimeDiscount();
//        }
//	}
//   
//    public void StrHit()
//    {
//        model.Damage += 1;
////        if (model.Damage >= 3)
////        {
////            model.Damage = 2;
////        }
//        Check = true;
//    }
//    public void TimeDiscount()
//    {
//       
//        timecd -= Time.deltaTime;
//        Debug.Log(time);
//        if (timecd <= 1)
//        {
//            model.Damage = model.dm;
//            Check = false;
//        } 
//    }
//
//}
