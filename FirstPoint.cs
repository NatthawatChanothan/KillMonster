using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using palinee;


public class FirstPoint : IState<AiBossDargon>
{


    public void OnEnter(AiBossDargon aiboss3)
    {

    }

    public void OnStay(AiBossDargon aiboss3)
    {
        aiboss3.animator.SetBool("Walk", true);
        if (null != aiboss3.Player)
        {
            aiboss3.Fsm.ChangState(AiBossDargon.Follow_STATE);
        }


        Point point = aiboss3.GetCurrentPoint();

        Vector3 position = aiboss3.Position;
        Vector3 target = point.Position;
        Vector3 velocity = aiboss3.Seek(target);

        target.y = position.y;

        float remainingDistance = Vector3.Distance(target, position);
        if (remainingDistance >= aiboss3.stoppingDistance)
        {


            aiboss3.Position = position + velocity;
            aiboss3.Rotate(velocity);
          
        

        }
        else if (point is ObservablePoint)
        {
         
            aiboss3.Fsm.ChangState(AiBossDargon.Around_STATE);
        }
        else
        {
   
            aiboss3.NextPoint();
        }
        if (aiboss3.HP<= 20)
        {
            aiboss3.Fsm.ChangState(AiBossDargon.FirstPoint2_STATE);

        }
    }

    public void OnExit(AiBossDargon aiboss3)
    {
        aiboss3.animator.SetBool("Walk", false);
    }


}


