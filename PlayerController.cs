using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TanksMP.Model;
using TanksMP.View;
using UnityEngine.Events;
using PixelCrushers.DialogueSystem;
using UnityEngine.Audio;
using palinee;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
namespace TanksMP
{
    namespace Controller
    {
        public class PlayerController : MonoBehaviour
        {
            [HideInInspector]
            public GameObject killedBy;
            public GameObject player;
            public int i; // boss2downstatePotral2
            public Transform tranformWeapon;
            public GameObject Shoot;
           // private int maxAttItem = 1;
            //private int maxHpItem = 1;
            public Animator animator;
            public GameObject end;
            public GameObject HpBarBoss;
            public GameObject HpBarBoss2;
            public GameObject HpBarBoss3;
            public float coolDownAtt = 3f;
            public float coolDownInvi =5f;
            public float coolDownShoot = 0.5f;
            public float coolDownTimeShoot;
            public float coolDownTimer;
            public float coolDownTimerInvi;
            public int time;
            public int maxTime; //เทสพิมพ์ดู
            public GameObject openMagic;
            public GameObject Uidie;
            public GameObject _talkabout1;
            public GameObject _talkabout2;
            public GameObject _talkabout3;
            public AudioSource attSound;
//            public int Fix
//            {
//                get{ return time; }
//                set{
//                    time = (int)value;
////                    if(time <= 0)
////                    {
////                        time = maxTime;
////                    }
//                }
//            }
            public GameObject CheckPoint0;
            public GameObject CheckPoint1;
            public GameObject CheckPoint2;
            public GameObject CheckPoint3;
            public GameObject CheckPoint4;

            public GameObject prefab;

//            public GameObject ItemHealth1;
//            public GameObject ItemShield;
            public AiTank boss1 ;
            public AiBoss2 boss2 ;
            public AiBossDargon boss3 ;
            public AiFsm Eveil;
            public PlayerModel model;
            private PlayerView view;
            public static int Point = 0;
            public float destoyMonster;
            public StrHit PowerAtt;
            public ItemHP HP;
       
            public GameObject playerViewObject;
            public GameObject playerModelObject;
            public Check check;
            public Rigidbody rb;

            private IEnumerator coroutine;
            public bool checkTimeCdShoot;
            public int Coin; //CoinAll
            public int att;   //PlayerPrefs form Shop
            public int hp;    //PlayerPrefs form Shop
            public int hiden; //PlayerPrefs form Shop 
       

            void Awake()
            {

//                PowerAtt = GameObject.Find("StrHit").GetComponent<StrHit>();
//
//                HP = GameObject.Find("ItemHP").GetComponent<ItemHP>();
//                model = GameObject.Find("PlayerModel").GetComponent<PlayerModel>();
            }



            void Start()
            {
                
                att = PlayerPrefs.GetInt("PowerAtt"); /// GetIn Item show
                hp = PlayerPrefs.GetInt("HP");
                hiden = PlayerPrefs.GetInt("Hiden");
               
                Debug.Log(PlayerPrefs.GetInt("PowerAtt"));  
                Debug.Log(PlayerPrefs.GetInt("HP"));  // show console
      

                model = playerModelObject.GetComponent<PlayerModel>();
                view = playerViewObject.GetComponent<PlayerView>();
                 
                prefab = Resources.Load("weapon") as GameObject;
       
            }


            public void Update()
            {

                if (coolDownTimer > 0)
                {
                    coolDownTimer -= Time.deltaTime;

                }
               
                if (coolDownTimer < 0)
                {
                    coolDownTimer = 0;
                    view.fxAtt.gameObject.SetActive(false);
                    model.Damage= 1;
                 
                }
                if (coolDownTimerInvi > 0)
                {
                    coolDownTimerInvi -= Time.deltaTime;

                }
                if (coolDownTimerInvi < 0)
                {
                    model.invisible = false;
                    coolDownTimerInvi = 0;

                }

                if (coolDownTimeShoot > 0)// Cooldown waporn sence three
                {
                    coolDownTimeShoot -= Time.deltaTime;
                    checkTimeCdShoot = true;
                }
                if (coolDownTimeShoot <= 0)
                {
                    checkTimeCdShoot =  false;
                    coolDownTimeShoot = 0;
                }
            }

//-----------------------------------------------------------------------------------------------------------------------------------------------//
            public void Move()
            {

                var x = CrossPlatformInputManager.GetAxis("Horizontal") * Time.deltaTime * 4;//model.moveRotaion; //X
                var z = CrossPlatformInputManager.GetAxis("Vertical") * Time.deltaTime * model.m_MoveSpeed; //Y

                 var horizontal2 = CrossPlatformInputManager.GetAxis("Horizontal_2") * Time.deltaTime * model.speedRotation;

                transform.Rotate(0, horizontal2, 0);
                transform.Translate(x, 0, z);

//                transform.Rotate(0, x, 0);
//                transform.Translate(0, 0, z);

               
            }
//------------------------------------------------------------------------------------------------------------------------------------------------//

//            public void RotatTurret(Vector2 direction = default(Vector2))
//            {
//                if (direction == Vector2.zero)
//                    return;
//                model.turretRotation = (short)Quaternion.LookRotation(new Vector3(direction.x, 0, direction.y)).eulerAngles.y;
//                model.turret.rotation = Quaternion.Euler(0, model.turretRotation, 0);
//            }

//-----------------------------------TakeDamage-------------------------------------------------------------------------------------------------------//

            public void TakeDamage()
            {
                if (model.Health <= 0)
                {
              
                    Uidie.gameObject.SetActive(true); // show UI 
                    player.gameObject.SetActive(false);
                  
                } 
            }

//---------------------------------------------------------------------------------------------------------------------------------------------------//



//            public void Takeshield()
//            {
//                print("asdf");
//                view.shieldSlider.value  -= 1;
//
//                    if (view.shieldSlider.value == 0)
//                    {
//                        TakeDamage();
//                    }   
//            }

//----------------------------------------------D i e -------------------------------------------------------------------//
            public void Die()
            {
                if (Point == 0)
                {
                    Uidie.gameObject.SetActive(false);
                    player.gameObject.SetActive(true);
                    model.Health = model.maxHealth;
                    model.transform.position = CheckPoint0.transform.position;

                }
                if (Point == 1)
                {
                    Uidie.gameObject.SetActive(false);
                    player.gameObject.SetActive(true);
                    model.Health = model.maxHealth;
                    model.transform.position = CheckPoint1.transform.position;
                    boss1.Health = boss1.HPMax;
                  
                }
                if (Point == 2)
                {
                    Uidie.gameObject.SetActive(false);
                    player.gameObject.SetActive(true);
                    model.Health = model.maxHealth;
                    model.transform.position = CheckPoint2.transform.position;


                }
                if (Point == 3)
                {
                    Uidie.gameObject.SetActive(false);
                    player.gameObject.SetActive(true);
                    model.Health = model.maxHealth;
                    model.transform.position = CheckPoint3.transform.position;
                    boss2.Health = boss2.HPMax;
                   
                }
                if (Point == 4)
                {
                    Uidie.gameObject.SetActive(false);
                    player.gameObject.SetActive(true);
                    model.Health = model.maxHealth;
                    model.transform.position = CheckPoint4.transform.position;
                    boss3.Health = boss3.HPMax;
                  
                }
            }
//--------------------------------------------------------------------------------------------------------------------// 


//            public  PhotonView GetView()
//            {
//                return this.photonView;
//            }

//--------------------------------------------------------------------------------------------------------------------//
            public void OnTriggerEnter(Collider coll)
            {

//                if (coll.gameObject.tag == "b1")
//                {
//                    _talkabout1.gameObject.SetActive(false);
//                }
//                if (coll.gameObject.tag == "b2")
//                {
//                    _talkabout2.gameObject.SetActive(false);
//                }
//                if (coll.gameObject.tag == "b3")
//                {
//                    _talkabout3.gameObject.SetActive(false);
//                }
                if (coll.gameObject.tag == "TextEvent") // Msg Box Gameplay
                {
                    model.textMsg.gameObject.SetActive(true);
                }
                if (coll.gameObject.tag == "ChackHpBarBoss")// Open Tag hp bar boss 1
                {
                    HpBarBoss.gameObject.SetActive(true);
                }
                if (coll.gameObject.tag == "ChackHpBarBoss2")// Open Tag hp bar boss 2
                {
                    HpBarBoss2.gameObject.SetActive(true);
                }
                if (coll.gameObject.tag == "ChackHpBarBoss3")// Open Tag hp bar boss 3
                {
                    HpBarBoss3.gameObject.SetActive(true);
                    openMagic.gameObject.SetActive(true);// show waporn button
                }
                if (coll.gameObject.tag == "CheckPoint1")
                {
                    Point = 1;
                }
                if (coll.gameObject.tag == "CheckPoint2")
                {
                    Point = 2;
                }
                if (coll.gameObject.tag == "CheckPoint3")
                {
                    Point = 3;
                }
                if (coll.gameObject.tag == "CheckPoint4")
                {
                    Point = 4;
                }
                if (coll.gameObject.tag == "end")
                {
                 //   SceneManager.LoadScene(3);// state win
                }
     
//                if (coll.gameObject.tag == "Bullet")
//                    {
//                          Takeshield();
//                    }
//
////                if (coll.gameObject.tag == "ItemHealth")
//                    {
//                        PushHealth();
//                        coll.gameObject.SetActive(false);
//                        ItemHealth1 = coll.gameObject;
//                        StartCoroutine("powerupHealth");
//                    }


//                if (coll.gameObject.tag == "ItemShield")
//                    {
////                        PushShield();
//                        coll.gameObject.SetActive(false);
//                        ItemShield = coll.gameObject;
//                        StartCoroutine("powerupHealth");
//                    }


//           
//                }
            }
 //---------------------------------------------------------------------------------------------------------------//

            public void OnTriggerExit(Collider coll) // Close Msg Box Gameplay
            {
                model.textMsg.gameObject.SetActive(false);

            }
//            public void AttSound(float value = 1f)
//            {
//                attSound.volume = value;
//                attSound.Play(); 
//           }
//--------------------------------------------------------------------------------------------------------------//

            public void OnCollisionEnter(Collision coll)
            {
                if (coll.gameObject.tag == "Evil")
                {
                    model.Health -= 1;
                    TakeDamage();
                }
                if (coll.gameObject.tag == "Boss1")
                {
                    model.Health -= boss1.Dm;
                    TakeDamage();
                }
                if (coll.gameObject.tag == "Boss2")
                {
                    model.Health -= boss2.Dm;
                    TakeDamage();
                }
                if (coll.gameObject.tag == "MonsterSpider") // miniboss 2 
                {
                    model.Health -= 1;
                    TakeDamage();
                }
                if (coll.gameObject.tag == "AiBoss3")
                {
                    model.Health -= boss3.Dm;
                    TakeDamage();
                }
                if (coll.gameObject.tag == "Evil")
                {

                    view.HitBlood.gameObject.SetActive (true); //Fx reaction monster

                }
                if (coll.gameObject.tag == "Boss1")
                {
                    view.HitBlood.gameObject.SetActive (true);

                }
                if (coll.gameObject.tag == "Boss2")
                {
                    view.HitBlood.gameObject.SetActive (true);

                }
                if (coll.gameObject.tag == "MonsterSpider")
                {
                    view.HitBlood.gameObject.SetActive (true);
                }
                if (coll.gameObject.tag == "AiBoss3")
                {
                    view.HitBlood.gameObject.SetActive (true);
                }

            }
            public void OnCollisionStay(Collision coll) // chon  monster nan nan
            {
                if (coll.gameObject.tag == "Evil")
                {
                    view.HitBlood.gameObject.SetActive (true);
                }
                if (coll.gameObject.tag == "Boss1")
                {
                    view.HitBlood.gameObject.SetActive (true);
                }
                if (coll.gameObject.tag == "Boss2")
                {
                    view.HitBlood.gameObject.SetActive (true);
                }
                if (coll.gameObject.tag == "MonsterSpider")
                {
                    view.HitBlood.gameObject.SetActive (true);
                }
                if (coll.gameObject.tag == "AiBoss3")
                {
                    view.HitBlood.gameObject.SetActive (true);
                }

            }
            public void OnCollisionExit(Collision coll)
            {
                if (coll.gameObject.tag == "Evil")
                {

                    view.HitBlood.gameObject.SetActive (false);
                }
                if (coll.gameObject.tag == "Boss1")
                {
                    view.HitBlood.gameObject.SetActive (false);
                }
                if (coll.gameObject.tag == "Boss2")
                {
                    view.HitBlood.gameObject.SetActive (false);
                }
                if (coll.gameObject.tag == "MonsterSpider")
                {
                    view.HitBlood.gameObject.SetActive (false);
                }
                if (coll.gameObject.tag == "AiBoss3")
                {
                    view.HitBlood.gameObject.SetActive (false);
                }
            }
          
//--------------------------------------------------------------------------------------------------------------//
//
//            IEnumerator powerupHealth()
//            {
//                yield return new WaitForSeconds(6f);
//                ItemHealth1.SetActive(true);
//            }
//
//
//
//            public void PushShield()
//            {
//                view.shieldSlider.value = 6;
//            }


//
//            public void PushHealth()
//            {
//                model.Health += 3;
//            }



//------------------------------------------------------------------------------------//
//            public void ItemHp()
//            {
//                model.Health += model.maxHealth; ///?
//            }
//
//
//
//            public void StrHit()
//            {
//                model.Damage += 1; //current damage=1 , when clikcbutton damage =2... but not more than 3
//
//                if (model.Damage >= 3) // 
//                {
//                    model.Damage = 2; 
//                }
//            }


//---------------------------------------------------------------------------------//

            public void Att()
            {
                
                if(att >=1)
                {

//                    view.fxAtt.gameObject.SetActive(true);

                
                    Item itemAttack = new ItemAttackup();
                    itemAttack.Items(model,view,this);
                    //att -= maxAttItem; // - item 1
                    coolDownTimer = coolDownAtt; // cooldownAtt => cooldownTimer then calurator in update
                   

                }
            }




//-------------------------------------I t e m Hp Up------------------------------------------//
            public void ItemHPUP()
            {
                if(hp >=1)
                {
                    
                    view.fxHp.gameObject.SetActive(true);

                   // ItemHp();

                    Item itemHp = new ItemHp1();
                    itemHp.Items(model,view,this);

                }
            }

//-----------------------------------------------------------------------------------------//

            public void Invisible()
            {
                
                if (hiden >= 1)
                {
                  //  model.invisible = true;


                    view.fxHide.gameObject.SetActive(true);

                    Item itemInvisible = new ItemInvisible();
                    itemInvisible.Items(model,view,this);

                    coolDownTimerInvi = coolDownInvi;


                }
            }

//-------------------------------------------------------------------------------------------//

            IEnumerator ChackCountTime()
            {
                yield return new WaitForSeconds(10);
                Debug.Log("kkk");
            }

        


//--------------------------------------------------------------------------------------//
            public void TimeUP() //this method run alway in Event//
            {
//                if (Time.time >= model.Fix +10) // if time >= 10
//                {
//                    view.fxAtt.gameObject.SetActive(false);
//                    model.dm=model.Damage;
//                    model.invisible = false;
//
//                }
//                if (Time.time  >= timeStrat+timeCd)
//                   {
//                   
//                    timeStrat = Time.time;
//                    view.fxAtt.gameObject.SetActive(false);
//                    model.Damage = 1;
//                    model.invisible = false;
//
//                   }
            }
//-----------------------------------------------------------------------------------------//
            public void AttD() // wapon attack
            {
                //view.chackatt = true;
                //view.swordCollider.gameObject.SetActive(true);
               
                view.swordCollider2.gameObject.SetActive(true);
                animator.SetTrigger("Attack"); 
                animator.SetBool("Attack", true);
                animator.SetBool("on_Chock", false);
                Invoke("SwordDeactive", 1.3f);
                Invoke("OnSoundAtt", 0.5f);
            }
            public void OnSoundAtt()
            {
                view.audioSource.PlayOneShot(view.audioClip);
            }
//----------------------------------------------------------------------------------------//
            public void SwordDeactive()
            {
                animator.SetBool("Attack", false);
                view.swordCollider2.gameObject.SetActive(false);
                //view.swordCollider.gameObject.SetActive(false);
            }
//----------------------------------------------------------------------------------------//

            public void Shootmagic()
            { 
                
                if(checkTimeCdShoot == false)
                    {
                    coolDownTimeShoot = coolDownShoot;
                    GameObject weapon = (GameObject)Instantiate(prefab,Shoot.transform.position,Quaternion.LookRotation(player.transform.forward/2));
                   // GameObject weapon = Instantiate(prefab)as GameObject;

               //     weapon.transform.position = tranformWeapon.position;
             //   weapon.transform.position = Shoot.transform.position;
                Rigidbody rb = weapon.GetComponent<Rigidbody>(); 
                rb.velocity = transform.forward * 10 +transform.up *5;
                    animator.SetBool("on_knight",true);
                Destroy(weapon, 3f);
               
                    }
               
            }
 
        }
    }

     
}

