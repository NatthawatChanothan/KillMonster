using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using palinee;

public class Observ2 : IState<AiBoss2>
{
    // Non-Serialized
    private ObservablePoint m_Point;

    private int m_CurrentIndex;
    private float m_EndTime;

    private AiTank tank;



    #region IState implementation

    public void OnEnter(AiBoss2 aiBoss2)
    {


        m_Point = aiBoss2.GetCurrentPoint() as ObservablePoint;


        m_CurrentIndex = 0;
        m_EndTime = Time.time + m_Point.Duration;
    }

    public void OnStay(AiBoss2 aiBoss2)
    {
        aiBoss2.animator.SetBool("Confused", true);
        if (null != aiBoss2.Player)
        {
            aiBoss2.Fsm.ChangState(AiBoss2.CHASE_STATE);
        
        }
        if (null != aiBoss2.Player)
        {
            Debug.Log("ChangScane");
            //            SceneManager.LoadScene(2);

        }
        else
        {
        
            if (Time.time >= m_EndTime)
            {
                m_CurrentIndex++;
        
                if (m_CurrentIndex >= m_Point.Count)
                {
                    aiBoss2.NextPoint();
                    aiBoss2.Fsm.ChangState(AiBoss2.PATROL_STATE);
        
                    return;
                }
        
                m_EndTime = Time.time + m_Point.Duration;
            }
        
            aiBoss2.Rotate(m_Point.GetDirection(m_CurrentIndex));
        }
        if (aiBoss2.HP<10)
        {
            aiBoss2.Fsm.ChangState(AiBoss2.UPSTONE_STATE);

        }
    }

    public void OnExit(AiBoss2 aiBoss2)
    {
        aiBoss2.animator.SetBool("Confused", false);
    }


    #endregion
}


