using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using palinee;

    public class Observ : IState<AiTank>
    {
        // Non-Serialized
        private ObservablePoint m_Point;

        private int m_CurrentIndex;
        private float m_EndTime;

        private AiTank tank;
        
    

        #region IState implementation
        public void OnEnter(AiTank aitank)
        {
         

            m_Point = aitank.GetCurrentPoint() as ObservablePoint;


            m_CurrentIndex = 0;
            m_EndTime = Time.time + m_Point.Duration;
        }

        public void OnStay(AiTank aitank)
        {

//            if (null != aitank.Player)
//            {
//                aitank.Fsm.ChangState(AiTank.CHASE_STATE);
//
//            }
        if (null != aitank.Player)
        {
            Debug.Log("ChangScane");
//            SceneManager.LoadScene(2);

        }

//            else
//            {
//
//                if (Time.time >= m_EndTime)
//                {
//                    m_CurrentIndex++;
//
//                    if (m_CurrentIndex >= m_Point.Count)
//                    {
//                        aitank.NextPoint();
//                        aitank.Fsm.ChangState(AiTank.PATROL_STATE);
//
//                        return;
//                    }
//
//                    m_EndTime = Time.time + m_Point.Duration;
//                }
//
//                aitank.Rotate(m_Point.GetDirection(m_CurrentIndex));
//            }
        }

        public void OnExit(AiTank aitank)
        {

        }
   
        #endregion
    }


