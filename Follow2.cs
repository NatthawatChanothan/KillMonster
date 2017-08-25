using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using palinee;

public class Follow2 : IState<AiBossDargon>
{

   // private float m_ElapsedTime;
    //    #region IState implementation
    public void OnEnter(AiBossDargon aitank)
    {
       // m_ElapsedTime = 0;
    }

    public void OnStay(AiBossDargon aitank)
    {
        aitank.am.SetBool("FlyDown", true);
        aitank.am.SetBool("Fly", false);
        aitank.move();
        if (aitank.HP <= 0)
        {
            aitank.am.SetTrigger("Death");
            aitank.Dead();
        }

       
    }
    public void OnExit(AiBossDargon aitank)
    {
        aitank.moveSpeed = 5f;
    }

}

//#endregion