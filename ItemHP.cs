using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TanksMP.Controller;


public class ItemHP : MonoBehaviour
{

    public  int onHp = 0;
    public Text showText1;
    //public ShowCoin h;
    public int playerC; //Main Coin**

    public void Start()
    {

    }
    public void OnHP()
    {
        playerC = PlayerPrefs.GetInt("coin");
        if (playerC >= 50)
        {
            
            onHp += 1;
            playerC -= 50;
          
            PlayerPrefs.SetInt("coin", playerC);
            PlayerPrefs.SetInt("HP", onHp);
            ShowItem();
            //h.TextCoin();
        }
    }

    public void ShowItem()
    {
        showText1.text = onHp.ToString();
    }

}
