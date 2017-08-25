using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PixelCrushers.DialogueSystem;

using TanksMP.Controller;


public class ShowCoin : MonoBehaviour {
   
    public Text showCoin;


    public void Update()
    {
        TextCoin();  
    }
    public void TextCoin()
    {
     
        showCoin.text = PlayerPrefs.GetInt("coin").ToString()+ "$";

    }

}
