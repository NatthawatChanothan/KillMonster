using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangScale : IState<AiBossDargon>
{
    
    public void OnEnter(AiBossDargon aitank)
    {
        

	}
    public void OnStay(AiBossDargon aitank)
    {

        aitank.Fsm.ChangState(AiBossDargon.Follow2_STATE);

    }
    public void OnExit(AiBossDargon aitank)
    {

    }

}
