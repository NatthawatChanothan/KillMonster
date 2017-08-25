using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TanksMP.View;

public class Invisible : MonoBehaviour
{
    public  int hiden = 0;

    public Text textHiden;
    public PlayerView view;
 
    public ItemHP showCoin;


    public void OnHiden()
    {
        showCoin.playerC = PlayerPrefs.GetInt("coin");    
        if(showCoin.playerC >=80)
        {

            showCoin.playerC -= 80;
            hiden += 1;
            PlayerPrefs.SetInt("coin", showCoin.playerC);
            PlayerPrefs.SetInt("Hiden", hiden);
            StringHide();

       }

    }


    public void StringHide()
    {
        textHiden.text = hiden.ToString();
    }

}
