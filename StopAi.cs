using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using palinee;

public class StopAi : IState<AiTank>
{
  
    public void OnEnter(AiTank aitank)
    {
        
    }

    public void OnStay(AiTank aitank)
    {
        aitank.Position = aitank.transform.position;
        aitank.animator.SetBool("Walk", false);
        aitank.transform.LookAt(aitank.traget);

        if (null != aitank.Player)
        {
            aitank.Fsm.ChangState(AiTank.CHASE_STATE);
        }
    }
    public void OnExit(AiTank aitank)
    {

    }

}

