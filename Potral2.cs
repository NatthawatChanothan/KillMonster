using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using palinee;
using UnityEngine.SceneManagement;

public class Patrol2 : IState<AiBoss2>
{

    #region IState implementation

    public void OnEnter(AiBoss2 aiBoss2)
    {

    }

    public void OnStay(AiBoss2 aiBoss2)
    {
        Debug.Log("Potral2");
        aiBoss2.animator.SetBool("Walk", true);
        if (null != aiBoss2.Player)
            {
            aiBoss2.Fsm.ChangState(AiBoss2.CHASE_STATE);
            }

       
        Point point = aiBoss2.GetCurrentPoint();

        Vector3 position = aiBoss2.Position;
        Vector3 target = point.Position;
        Vector3 velocity = aiBoss2.Seek(target);

        target.y = position.y;

        float remainingDistance = Vector3.Distance(target,  position); //remainingDistance Ai to Point
        if (remainingDistance >= aiBoss2.stoppingDistance)
        {
            aiBoss2.t = true;
            aiBoss2.Position = position + velocity;
            aiBoss2.Rotate(velocity);
        }
        else if (point is ObservablePoint)
        {
            aiBoss2.Fsm.ChangState(AiBoss2.OBSERVE_STATE);
        }
        else
        {

            aiBoss2.NextPoint();
        }
        if (aiBoss2.HP<10)
        {
            aiBoss2.Fsm.ChangState(AiBoss2.UPSTONE_STATE);

        }
    }

    public void OnExit(AiBoss2 aiBoss2)
    {
        aiBoss2.animator.SetBool("Walk", false);
    }

    #endregion
}


