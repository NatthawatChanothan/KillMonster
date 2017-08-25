using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksMP.Controller;
using TanksMP.Model;
using TanksMP.View;

public class ItemInvisible : Item
{
    public override void Items(PlayerModel model,PlayerView view,PlayerController c)
    {
        model.invisible = true;
        c.hiden -= 1;

        //  model.Fix = (int)Time.time; //keep time put model.Fix alway//

        if (c.hiden <= 0)
        {
            PlayerPrefs.DeleteKey("Hiden");
        }
    }

}
