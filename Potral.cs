using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using palinee;
using UnityEngine.SceneManagement;

    public class Patrol : IState<AiTank>
    {
   
        #region IState implementation
        public void OnEnter(AiTank aitank)
        {
        
        }

    public void OnStay(AiTank aitank)
        {


        if (null != aitank.Player)
        {
            Debug.Log("ChangScane");
//            SceneManager.LoadScene(2);
            aitank.Fsm.ChangState(AiTank.CHASE_STATE);
        }


            Point point = aitank.GetCurrentPoint();

            Vector3 position = aitank.Position;
            Vector3 target = point.Position;
            Vector3 velocity = aitank.Seek(target);
           
            target.y = position.y;

            float remainingDistance = Vector3.Distance(target,position);
            if (remainingDistance >= aitank.stoppingDistance)
            {
            
                aitank.AnimatorMove();
                aitank.Position = position + velocity;
                aitank.Rotate(velocity);

            if (aitank.t == true)
            {
                aitank.AnimatorMove();
                aitank.AnimatorHitGroundFalse();
            }
            else
            {
                aitank.AnimatormoveFalse();

            }
            }

      
//            else if (point is ObservablePoint)
//            {
//            
//                aitank.Fsm.ChangState(AiTank.OBSERVE_STATE);
//            }
//            else
//            {
//            
//                aitank.NextPoint();
//            }
        }

        public void OnExit(AiTank aitank)
        {

        }

        #endregion
    }


