using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using palinee;


public class FirstPoint2 : IState<AiBossDargon>
{


    public void OnEnter(AiBossDargon aiboss3)
    {

    }

    public void OnStay(AiBossDargon aiboss3)
    {
        aiboss3.am.SetBool("Fly", true);
        aiboss3.am.SetBool("Attack1", false);
        aiboss3.am.SetBool("Stand", false);

        aiboss3.moveSpeed = 20;
        Vector3 position = aiboss3.Position;
        Vector3 target = aiboss3.a.transform.position;
        Vector3 velocity = aiboss3.Seek(target);


        target.y = position.y;

        float remainingDistance = Vector3.Distance(target, position);
        if (remainingDistance >= aiboss3.stoppingDistance)
        {

            //  aiBoss2.AnimatorMove();
            aiboss3.Position = position + velocity;
            aiboss3.Rotate(velocity);
            if (aiboss3.t == false)
            {
                //aiboss3.transform.position = target;
                aiboss3.Fsm.ChangState(AiBossDargon.Follow2_STATE); 
            }
        }
        //if (position == target)
       // {
           // aiboss3.Fsm.ChangState(AiBossDargon.ChangScale_SATE); 
       // }
    }

    public void OnExit(AiBossDargon aiboss3)
    {

    }


}


