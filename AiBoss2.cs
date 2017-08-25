using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksMP.Model;
using TanksMP.View;
using TanksMP.Controller;
using palinee;
using UnityEngine.SceneManagement;

public class AiBoss2 : MonoBehaviour
{
    public const byte PATROL_STATE = 1;
    public const byte OBSERVE_STATE = 2;
    public const byte CHASE_STATE = 3;
    public const byte UPSTONE_STATE = 4;
    public const byte Monster_STATE = 5;
    public const byte STATE_PRO = 6;
    public const byte OBSER22_STATE = 7;
    public const byte CHASE22_STATE = 8;
    public GameObject end;
    public int Dm;
    private bool m_IsChasing;
    public GameObject SpiderMonster;
    public float radiusAtt;
    public bool drawGizmos = true;
    float timer = 5f;
    public Rigidbody m_Rid;
    public int chackSated = 0;
    [Space]
    public int checkBossTwo_animatHP;
    public bool t = true; // chack spider stop
    public float coolDown;
    public float moveSpeed = 4f;
    public float rotateSpeed = 5f;
    public Transform traget;
    public float radius = 0.5f;
    public int HP ;
    public int HPMax = 10;
    public Animator animator;
    [Space]
    public EyeVision eyeVision;
    public HUD2 hud2;
    [Space]
    public float stoppingDistance = 0.1f;

    public Path path;
    public Path pathUpSpier;


    public Transform a;//paht top
  
    public Transform playerlook; //lookatPlayer

    //      public GameObject paths;
    public PlayerView view;
    public PlayerModel model;
    public PlayerController controller;
  
    public Vector3 Position
    {
        get
        {
            return transform.position;
        }
        set
        {
            transform.position = value;
        }
    }

    // Property
    public Fsm<AiBoss2> Fsm { get; private set; }

    public PlayerModel Player { get; private set; }

    // Non-Serialized
    private bool m_IsForward = true;
    private int m_CurrentPointIndex = 0;


    void Awake()
    {

        eyeVision.onEnter.AddListener(OnObjectInSight);
        eyeVision.onExit.AddListener(OnObjectOutSight);

   
        m_Rid = GetComponent<Rigidbody>();

        Fsm = new Fsm<AiBoss2>(this);

        Fsm.AddState(PATROL_STATE, new Patrol2());
        Fsm.AddState(OBSERVE_STATE, new Observ2());
        Fsm.AddState(CHASE_STATE, new Chase2());
        Fsm.AddState(UPSTONE_STATE, new UpStone());
        Fsm.AddState(Monster_STATE, new StateMonster());
        Fsm.AddState(STATE_PRO, new StatePro());
        Fsm.AddState(OBSER22_STATE, new Observ22());
        Fsm.AddState(CHASE22_STATE, new Chase22());
    }


    void Start()
    {
        
        //        RayCast();

        //        path = GameObject.FindObjectOfType<PathAi>();
    }

    void Update()
    {
        Fsm.Update();
        RayCast();

        var Distan = Vector3.Distance(playerlook.position, transform.position);
        if (Distan <= radiusAtt)
        {
            transform.LookAt(playerlook);
            if (HP < 10)
            {
                return;
            }
        }
 
//        else if(Distan >= radiusAtt)
//        {
//           
//            Fsm.ChangState(PATROL_STATE);
//            if (HP<10)
//            {
//                Fsm.ChangState(AiBoss2.UPSTONE_STATE);
//
//            }
//        }

    }

    void OnEnable()
    {


        Fsm.ChangState(PATROL_STATE);
    }

    void OnDisable()
    {
        Fsm.ChangState(0);
    }

    public void SetChaseState()
    {
        Fsm.ChangState(CHASE_STATE);
    }

    public void SetPatrolState()
    {
        Fsm.ChangState(PATROL_STATE);
    }

    void OnDrawGizmos()
    {
        if (!drawGizmos)
            return;

        Vector3 target = GetCurrentPoint().Position;
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Position, GetCurrentPoint().Position);

        if (null != Player)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(Position, Player.Position);
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radiusAtt);
    }

 
    public Vector3 Seek(Vector3 target)
    {
        Vector3 displacement = (target - Position);

        Vector3 direction = displacement.normalized;

        return direction * moveSpeed * Time.deltaTime;

    }
   

    public  int Health
    {

        get 
        { 
            return HP; 
        }


        set 
        { 
            HP = value;
            hud2.OnHealthChange();
        }

    }


    public void Rotate(Vector3 direction)
    {

        Quaternion lookAt = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookAt, rotateSpeed);
    }

    public Point GetCurrentPoint()
    {

        return path.GetPoint(m_CurrentPointIndex);
    }



    public void NextPoint()
    {
        if (path.Count <= 1)
        {
            m_CurrentPointIndex = 0;
            return;
        }

        if (m_IsForward)
        {
            m_CurrentPointIndex++;

            if (m_CurrentPointIndex >= path.Count)
            {
                m_IsForward = false;
                m_CurrentPointIndex = path.Count - 2;
            }
        }
        else
        {
            m_CurrentPointIndex--;

            if (m_CurrentPointIndex < 0)
            {
                m_IsForward = true;
                m_CurrentPointIndex = 1;
            }
        }
    }


    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Sword")
        {
            Health -= model.Damage;

            chackSated += 1;

            PlayerPrefs.SetInt("ChackSated", chackSated);

            //            Destroy(gameObject, 3f);
            //            SceneManager.LoadScene(4);
        }
        if (Health <= 0)
        {
            Dead();
        }
        if (coll.gameObject.tag == "PointRed")
        {  
            t = false;
            m_Rid.useGravity = true;
            transform.LookAt(playerlook);
            Fsm.ChangState(AiBoss2.Monster_STATE);

        }
        if(coll.gameObject.tag == "gavityture")
        {
            m_Rid.useGravity = false;
        }
    }
        

    public void OnObjectInSight(Collider c)
    {
        if (c.gameObject.tag == "Player")
        { 
            Player = c.GetComponent<PlayerModel>();
        }
    }

    public void OnObjectOutSight(Collider c)
    {
        if (c.tag == "Player")
        {
            Player = null;
        }
    }

    void RayCast()
    {

        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.forward * 6, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z), transform.forward, out hit, 6f))
        { 
            if (hit.collider.tag == "Player")
            {

                timer -= Time.deltaTime;
                // AnimatorHitGround();
                //animator.SetBool("Walk", false);
                //              Debug.Log(timer + "kuy");
                animator.SetBool("Attack1", true);
                animator.SetBool("Walk", false);
                if (timer <= 3.80f)
                {
                  
                }
                if (checkBossTwo_animatHP != 1)
                {
                    if (HP < 10)
                    {
                        Fsm.ChangState(AiBoss2.UPSTONE_STATE);
                    }
                }
            

            } 
            if (Player != null)  //if invisible is ture Do ///////
            {
                if (Vector3.Distance(Player.Position, transform.position) > 10)
                {

                    Fsm.ChangState(PATROL_STATE);
                    animator.SetBool("Walk", false);
                    animator.SetBool("Attack1", true);
                    if (checkBossTwo_animatHP != 1)
                    {
                        if (HP < 10)
                        {
                        
                            Fsm.ChangState(AiBoss2.UPSTONE_STATE);
                        }
                    }
                }
            }
      
        }
        else
        {
            animator.SetBool("Attack1", false);
        }


    }
//    public void loopinstanspider()
//    {
//        for (int i = 0; i < 10; i++)
//        {
//            Instantiate(prefab, positionspider, Quaternion.identity);
//        }
//    }

    //    public void OnTriggerEnter(Collider c)
    //    {
    //        if (c.gameObject.tag == "Sword")
    //        {
    //            animator.SetBool("TakeDamage", true);
    //
    //            HP -= model.Damage;
    //
    //        }
    //
    //        if (hp <= 0)
    //        {
    //            Destroy(gameObject);
    //        }
    //
    //
    //    }
    public void Dead()
    {
        animator.SetTrigger ("Death");
        controller.HpBarBoss2.gameObject.SetActive(false);
        Destroy(controller.HpBarBoss2.gameObject);
        Destroy(gameObject,3f);
        end.SetActive(true);
    }
}

