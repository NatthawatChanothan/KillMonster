using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using palinee;

public class StateMonster : IState<AiBoss2>
{



    public void OnEnter(AiBoss2 aiBoss2)
    {
        aiBoss2.SpiderMonster.SetActive(true);
    }

    public void OnStay(AiBoss2 aiBoss2)
    {
        aiBoss2.SpiderMonster.SetActive(true);
       
        if (aiBoss2.controller.i >= 4)
        {
            aiBoss2.Fsm.ChangState(AiBoss2.STATE_PRO);
        }
    }

    public void OnExit(AiBoss2 aiBoss2)
    {
//        aiBoss2.SpiderMonster.SetActive(true);
//        if (aiBoss2.controller.i >= 8)
//        {
//            aiBoss2.Fsm.ChangState(AiBoss2.PATROL_STATE);
//        }
    }

}


