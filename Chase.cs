using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using palinee;

    public class Chase : IState<AiTank>
    {
        private float m_ElapsedTime;

        public void OnEnter(AiTank aitank)
        {
            m_ElapsedTime = 0;
        }
        
        public void OnStay(AiTank aitank)
        {
        if (aitank.model.invisible == false)
        {
            if (null != aitank.Player)
            {
                Debug.Log(aitank.Player);
                Vector3 position = aitank.Position;
                Vector3 target = aitank.Player.Position;
                Vector3 velocity = aitank.Seek(target);

                float remainingDistance = Vector3.Distance(target, position);
            if (remainingDistance >= aitank.radius)
                {
                aitank.Position = position + velocity;
                aitank.AnimatorMove();
                }
                aitank.Rotate(velocity);
            }
       
            else
            {
            
            aitank.t = true;
                m_ElapsedTime += Time.deltaTime;

                if (m_ElapsedTime > 1f)
                {
                    aitank.Fsm.ChangState(AiTank.PATROL_STATE);
                }
            }
            
        }
    }
        public void OnExit(AiTank aitank)
        {

        }

    }

