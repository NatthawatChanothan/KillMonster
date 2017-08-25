using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksMP.Model;
using TanksMP.View;

public class TestLoadScrpit : MonoBehaviour {
//

//    private StrHit strHitItem;
//    private ItemHP hpItem;
//    private PlayerModel healthModel;
//
//    class SaveDataFormat
//    {
//
//        public int hitItem;
//        public int itemHP;
//        public int healt;
//
//    }
//
//    void Awake()
//    {
//        strHitItem = GameObject.Find("StrHit").GetComponent<StrHit>();
//
//        hpItem = GameObject.Find("ItemHP").GetComponent<ItemHP>();
//        healthModel = GameObject.Find("PlayerModel").GetComponent<PlayerModel>();
//
//    }
    public void onLoad()
    {
        if (PlayerPrefs.HasKey("save_data") == false)
        {
            return;
        }

        Debug.Log("Load");
        string str = PlayerPrefs.GetString("save_data");

    }
	
	void Start ()
    {
        
		
	}
	
	
	void Update () 
    {
		
	}
}
