using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using palinee;

public class Around : IState<AiBossDargon>
{

    private ObservablePoint m_Point;

    private int m_CurrentIndex;
    private float m_EndTime;

    private AiTank tank;




//    #region IState implementation
    public void OnEnter(AiBossDargon aitank)
    {
//
        aitank.am.SetBool("Stand", true);
        m_Point = aitank.GetCurrentPoint() as ObservablePoint;


        m_CurrentIndex = 0;
        m_EndTime = Time.time + m_Point.Duration;
    }

    public void OnStay(AiBossDargon aitank)
    {


        if (null != aitank.Player)
        {
            //aitank.animator.SetBool("Walk",false);
            aitank.Fsm.ChangState(AiBossDargon.Follow_STATE);

        }
        else
        {
           
            //                Debug.Log("EE");
            if (Time.time >= m_EndTime)
            {

                m_CurrentIndex++;

                if (m_CurrentIndex >= m_Point.Count)
                {
                    aitank.NextPoint();
                    aitank.Fsm.ChangState(AiBossDargon.FirstPoint_STATE);

                    return;
                }

                m_EndTime = Time.time + m_Point.Duration;
            }

            aitank.Rotate(m_Point.GetDirection(m_CurrentIndex));
        }
        if (aitank.HP<20)
        {
            aitank.Fsm.ChangState(AiBossDargon.FirstPoint2_STATE);


        }
    }

    public void OnExit(AiBossDargon aitank)
    {

    }

//    #endregion
}


