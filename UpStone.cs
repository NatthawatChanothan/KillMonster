using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using palinee;

public class UpStone : IState<AiBoss2>
{

   

    public void OnEnter(AiBoss2 aiBoss2)
    {
        aiBoss2.checkBossTwo_animatHP = 1;
    }

    public void OnStay(AiBoss2 aiBoss2)
    {
        aiBoss2.moveSpeed = 10;
        Vector3 position = aiBoss2.Position;
        Vector3 target = aiBoss2.a.transform.position;
        Vector3 velocity = aiBoss2.Seek(target);
 

        target.y = position.y;

        float remainingDistance = Vector3.Distance(target, position);
        if (remainingDistance >= aiBoss2.stoppingDistance)
        {
          
            //  aiBoss2.AnimatorMove();
            aiBoss2.Position = position + velocity;
            aiBoss2.Rotate(velocity);

            if (aiBoss2.t == false)
            {
                aiBoss2.transform.position = target;
            }
        }
        if (position == target)
        {
            aiBoss2.Fsm.ChangState(AiBoss2.Monster_STATE);
        }
            

    }

    public void OnExit(AiBoss2 aiBoss2)
    {
        aiBoss2.moveSpeed = 5;
    }
 
}


