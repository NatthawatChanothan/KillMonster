using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksMP.Controller;
using TanksMP.Model;
using TanksMP.View;

public class ItemAttackup : Item
{

    public override void Items(PlayerModel model,PlayerView view,PlayerController c)
    {
        
        view.fxAtt.gameObject.SetActive(true);
        c.att -= 1;

        model.Damage += 1;
       // model.Fix = (int)Time.time;
       
        if (model.Damage >= model.dm)// model.dm => max dm
        {
            model.Damage =  model.dm;
        }
        if (c.att <= 0 )
        {
            PlayerPrefs.DeleteKey("PowerAtt");
        }
    }

}
