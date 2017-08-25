using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


using palinee;

public class Chase22 : IState<AiBoss2>
{
    private float m_ElapsedTime;

    #region IState implementation
    public void OnEnter(AiBoss2 aiBoss2)
    {
        m_ElapsedTime = 0;
    }

    public void OnStay(AiBoss2 aiBoss2)
    {
        if (aiBoss2.model.invisible == false)
        {
            if (null != aiBoss2.Player)
            {
                Debug.Log(aiBoss2.Player);
                Vector3 position = aiBoss2.Position;
                Vector3 target = aiBoss2.Player.Position;
                Vector3 velocity = aiBoss2.Seek(target);
                aiBoss2.moveSpeed = 5f;
                // aiBoss2.AnimatormoveFalse();
                float remainingDistance = Vector3.Distance(target, position);
                if (remainingDistance >= aiBoss2.radius)
                {
                    aiBoss2.Position = position + velocity;
                    //      aiBoss2.AnimatorMove();

                }
                aiBoss2.Rotate(velocity);

            }
        }
        else
        {
            aiBoss2.t = true;
            m_ElapsedTime += Time.deltaTime;

            if (m_ElapsedTime > 1f)
            {
                aiBoss2.moveSpeed = 3f;
                aiBoss2.Fsm.ChangState(AiBoss2.STATE_PRO);
            }
        }
       

    }
    public void OnExit(AiBoss2 aiBoss2)
    {

    }

}

#endregion