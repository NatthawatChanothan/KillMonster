using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksMP.Controller;
using TanksMP.Model;
using TanksMP.View;

public class ItemHp1 : Item {

    public override void Items(PlayerModel model,PlayerView view,PlayerController c)
    {
        model.Health += model.maxHealth;

        c.hp -= 1; //1

        Debug.Log(c.hp);

        if (c.hp <= 0)
        {
            PlayerPrefs.DeleteKey("HP");
        }
    }
}
