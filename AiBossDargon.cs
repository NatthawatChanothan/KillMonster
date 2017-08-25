using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksMP.Model;
using TanksMP.View;
using TanksMP.Controller;
using palinee;
using UnityEngine.SceneManagement;

public class AiBossDargon : MonoBehaviour
{
    public const byte FirstPoint_STATE = 1;
    public const byte Around_STATE = 2;
    public const byte Follow_STATE = 3;
   // public const byte ChangScale_SATE = 4;
    public const byte FirstPoint2_STATE = 4;
    public const byte Follow2_STATE = 5;
    private bool m_IsChasing;
    public Animator animator;
    public float radiusAtt;
    //    public Vector3 positionspider; //positionspider
    //    public Transform prefab; //spidermonster
    public bool drawGizmos = true;
    //float timer = 5f;
    public Rigidbody m_Rid;
    public int chackSated = 0;
    [Space]
    public int Dm ;
    public bool t = true; // chack spider stop

    public float moveSpeed ;
    public float rotateSpeed = 5f;
    public Transform traget;
    public float radius = 0.5f;
    public int HP ;
    public int HPMax = 30;
    public Animator am;
    [Space]
    public EyeVision eyeVision;
    public HUD3 hud3;
    [Space]
    public float stoppingDistance = 0.1f;
    public BoxCollider b; //scale boxboss3
    public Path path;
    public Path pathUpSpier;
    public GameObject FX;
    public Rigidbody rb;
    public Transform a;//paht top

    public Transform playerlook; //lookatPlayer
    public GameObject PlayerObject;
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
    public Fsm<AiBossDargon> Fsm { get; private set; }

    public PlayerModel Player { get; private set; }

    // Non-Serialized
    private bool m_IsForward = true;
    private int m_CurrentPointIndex = 0;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        eyeVision.onEnter.AddListener(OnObjectInSight);
        eyeVision.onExit.AddListener(OnObjectOutSight);


        m_Rid = GetComponent<Rigidbody>();

        Fsm = new Fsm<AiBossDargon>(this);

        Fsm.AddState(FirstPoint_STATE, new FirstPoint());
        Fsm.AddState(Around_STATE, new Around());
        Fsm.AddState(Follow_STATE, new Follow());
       // Fsm.AddState(ChangScale_SATE, new ChangScale());
        Fsm.AddState(FirstPoint2_STATE, new FirstPoint2());
        Fsm.AddState(Follow2_STATE, new Follow2());
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
        }
    }

    void OnEnable()
    {


        Fsm.ChangState(FirstPoint_STATE);
    }

    void OnDisable()
    {
        Fsm.ChangState(0);
    }

    public void SetChaseState()
    {
        Fsm.ChangState(Follow_STATE);
    }

    public void SetPatrolState()
    {
        Fsm.ChangState(FirstPoint_STATE);
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
            hud3.OnHealthChange();
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
        if (coll.gameObject.tag == "PointGreen")
        {  
           t = false;
          transform.LookAt(playerlook);
         
      //    Fsm.ChangState(AiBossDargon.ChangScale_SATE); 
        }
        if (coll.gameObject.tag == "DargonJump")
        {
            rb.useGravity = false;

        }
//        if (coll.gameObject.tag == "AnimatorPoinRed")
//        {
//            am.SetBool("Stand", false);
//        }
//       
       
    }


    //
    //    public void  AnimatorMove()
    //    {
    //        animator.SetBool("Walk", true);
    //    }
    //
    //    public void AnimatormoveFalse()
    //    {
    //
    //        //        Vector3 to = new Vector3(0,0,150);
    //        transform.LookAt(traget);
    //    }
    //
    //    public void AnimatorHitGround()
    //    {
    //        animator.SetBool("Hit Ground", true);
    //    }
    //
    //    public void AnimatorHitGroundFalse()
    //    {
    //        animator.SetBool("Hit Ground", false);
    //    }
    //
    //    public void OpenObjectFx()
    //    {
    //        FX.gameObject.SetActive(true);
    //
    //    }

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
                am.SetBool("Stand", false);
                am.SetBool("Attack1", true);
            } 
           
            if (Player != null)  //if invisible is ture Do ///////
            {
                if (Vector3.Distance(Player.Position, transform.position) > 10)
                {
                 
                    Fsm.ChangState(FirstPoint_STATE);

                }
            }
        }
        else
        {
            am.SetBool("Attack1", false);
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
    public void move()
    {
        Vector3 displacement = PlayerObject.transform.position - transform.position;
        Vector3 direction = displacement.normalized;
        Vector3 velocity = direction * 10 * Time.deltaTime;

        //Position = Position + velocity;
        transform.position = transform.position + velocity;
        transform.LookAt(PlayerObject.transform.position );


    }
    public void Dead()
    {
        am.SetTrigger ("Death");
        controller.end.gameObject.SetActive(true);
        controller.HpBarBoss3.gameObject.SetActive(false);
        Destroy(controller.HpBarBoss3.gameObject);
        Destroy(gameObject,3f);
        am.SetBool("FlyDown", false);

    }

}

