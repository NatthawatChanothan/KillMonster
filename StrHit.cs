using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TanksMP.View;

public class StrHit : MonoBehaviour
{

    public  int strHit = 0;
    public Text showText2;
    public PlayerView view;
    public ItemHP showCoin;

    public void OnStrHit()
    {
        showCoin.playerC = PlayerPrefs.GetInt("coin");
        if (showCoin.playerC >= 80)
        {
    
            strHit += 1;
            showCoin.playerC -= 80;
            PlayerPrefs.SetInt("coin", showCoin.playerC);
            PlayerPrefs.SetInt("PowerAtt", strHit);
            ShowItemTwo();
        }
    }

    public void ShowItemTwo()
    {
        showText2.text = strHit.ToString();
    }
}
