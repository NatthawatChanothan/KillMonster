using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksMP.Model;
using TanksMP.View;
using palinee;
using TanksMP.Controller;
using UnityEngine.SceneManagement;

public class AiTank : MonoBehaviour
{

    public const byte PATROL_STATE = 1;
   // public const byte OBSERVE_STATE = 2;
    public const byte CHASE_STATE = 2;
    public const byte STOP_AI_STATE = 3;
    private bool m_IsChasing;
    public GameObject end;
    public bool drawGizmos = true;
    float timer = 5f;
    public Rigidbody m_Rid;
    public int chackSated = 0;
    [Space]
    public int Dm = 3;
    public float moveSpeed = 2f;
    public float rotateSpeed = 5f;
    public Transform traget;
    public float radius = 0.5f;
    public int HP ;
    public int HPMax = 15;
    public Animator animator;
    [Space]
    public EyeVision eyeVision;
    public HUD hud;
    [Space]
    public float stoppingDistance = 0.1f;
  
    public Path path;
    //public GameObject FX;
   
    public GameObject Box;
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
    public Fsm<AiTank> Fsm { get; private set; }

    public PlayerModel Player { get; private set; }

    // Non-Serialized
    private bool m_IsForward = true;
    private int m_CurrentPointIndex = 0;

 
    void Awake()
    {
            
        eyeVision.onEnter.AddListener(OnObjectInSight);
        eyeVision.onExit.AddListener(OnObjectOutSight);
    

        m_Rid = GetComponent<Rigidbody>();

        Fsm = new Fsm<AiTank>(this);

        Fsm.AddState(PATROL_STATE, new Patrol());
       // Fsm.AddState(OBSERVE_STATE, new Observ());
        Fsm.AddState(CHASE_STATE, new Chase());
        Fsm.AddState(STOP_AI_STATE,new StopAi()); 
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
    }
    //    void RayCast()
    //    {
    //        Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
    //        RaycastHit hit;
    //
    //        if (Physics.Raycast(new Vector3(transform.position.x,transform.position.y+ 0.5f,transform.position.z), transform.forward, out hit, 10f))
    //        {
    //            if (hit.collider.tag == "Player")
    //            {
    //                Player = hit.collider.gameObject.GetComponent<PlayerModel>();
    //
    //                Debug.Log("ss");
    ////                Fsm.ChangState(CHASE_STATE);
    //               
    //            }
    //
    //            if (Player != null)
    //            {
    //                if (Vector3.Distance(Player.Position, transform.position) > 10)
    //                {
    //                  
    //                    Fsm.ChangState(PATROL_STATE);
    //                   
    //                }
    //            }
    //        }
    //    }

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
            hud.OnHealthChange();
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
            Health -= 1;
            animator.SetBool("Spell", true);
            chackSated += 1;

            PlayerPrefs.SetInt("ChackSated", chackSated);

//            Destroy(gameObject, 3f);
        //  SceneManager.LoadScene(4);

        }
        if (Health <= 0)
        {
            Dead();
        }
        if (coll.gameObject.tag == "STOP")
        {  
            t = false;
            Fsm.ChangState(AiTank.STOP_AI_STATE);
        }
    }
    public void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "STOP")
        {  
            t = false;
            Fsm.ChangState(AiTank.STOP_AI_STATE);
        }
    }
    public void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Sword")
        {
            animator.SetBool("Spell", false);
        }
    }


    public bool t = true;

    public void  AnimatorMove()
    {
        animator.SetBool("Walk", true);
    }

    public void AnimatormoveFalse()
    {
        animator.SetBool("Walk", false);
//        Vector3 to = new Vector3(0,0,150);
        transform.LookAt(traget);
    }

    public void AnimatorHitGround()
    {
        animator.SetBool("Hit Ground", true);
    }

    public void AnimatorHitGroundFalse()
    {
        animator.SetBool("Hit Ground", false);
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
     
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.forward * 5, Color.green);

        RaycastHit hit;

        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), transform.forward, out hit, 5f))
        { 
            if (hit.collider.tag == "Player")
            {
                
                timer -= Time.deltaTime;
                AnimatorHitGround();
                animator.SetBool("Walk", false);
//              Debug.Log(timer + "kuy");

//
//                if (timer <= 3.80f)
//                {
//                    FX.gameObject.SetActive(true);
//                }
                if (Vector3.Distance(Player.Position, transform.position) > 10)
                {

                    Fsm.ChangState(PATROL_STATE);

                }
            }
            else
            {
                AnimatorHitGroundFalse();
            }
         
//            if (Player != null)  //if invisible is ture Do ///////
//            {
//                if (Vector3.Distance(Player.Position, transform.position) > 10)
//                {
//
//                    Fsm.ChangState(PATROL_STATE);
//
//                }
//            }
        }


    }

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
        animator.SetTrigger("Die");
        //controller.HpBarBoss.gameObject.SetActive(false);
        Destroy(controller.HpBarBoss.gameObject);
        Box.gameObject.SetActive(false);
        Destroy(gameObject,3f);
        end.gameObject.SetActive(true);
//        ChangScance.a = 1;
    }
}

