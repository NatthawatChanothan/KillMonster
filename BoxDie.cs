using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksMP.Controller;
public class BoxDie : MonoBehaviour 
{
    public PlayerController controller;

    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            
            controller.Uidie.gameObject.SetActive(true);
            controller.player.gameObject.SetActive(false);
        }
      
    }

}
