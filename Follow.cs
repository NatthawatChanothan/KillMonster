using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using palinee;

public class Follow : IState<AiBossDargon>
{
    
    private float m_ElapsedTime;
//    #region IState implementation
    public void OnEnter(AiBossDargon aitank)
    {
        m_ElapsedTime = 0;
    }

    public void OnStay(AiBossDargon aitank)
    {
        if (aitank.model.invisible == false)
        {
            if (null != aitank.Player)
            {
            
                Debug.Log(aitank.Player);
                Vector3 position = aitank.Position;
                Vector3 target = aitank.Player.Position;
                Vector3 velocity = aitank.Seek(target);
                aitank.moveSpeed = 4f;

                float remainingDistance = Vector3.Distance(target, position);
                if (remainingDistance >= aitank.radius)
                {
                    aitank.Position = position + velocity;
                    //aitank.AnimatorMove();
                }
                aitank.Rotate(velocity);
            }
        }
        else
        {

           // aitank.t = true;
            m_ElapsedTime += Time.deltaTime;

            if (m_ElapsedTime > 1f)
            {
                aitank.Fsm.ChangState(AiBossDargon.FirstPoint_STATE);
            }
        }
        if (aitank.HP<20)
        {
            aitank.Fsm.ChangState(AiBossDargon.FirstPoint2_STATE);


        }

    }
    public void OnExit(AiBossDargon aitank)
    {
        aitank.moveSpeed = 5f;
    }

}

//#endregion