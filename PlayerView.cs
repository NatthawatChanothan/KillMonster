using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

namespace TanksMP
{
    namespace View
    {
        
        [System.Serializable]
        public class InputPhysicsEvent : UnityEvent<Vector2>{} 
        [System.Serializable]
        public class HpEvent : UnityEvent<int>{}
        [System.Serializable]
        public class BulletEvent : UnityEvent<Collider>{}
        [System.Serializable]
        public class ItemHPEvent : UnityEvent{}
        [System.Serializable]
        public class ItemAttEvent : UnityEvent{}
        [System.Serializable]
        public class CDEvent : UnityEvent{}

       

        public class PlayerView : MonoBehaviour
        {
            public ItemHPEvent onItemHPEvent;
            public ItemAttEvent onItemAttEvent;
            public CDEvent onCD;
            public BulletEvent onBulletEvent;
            public InputPhysicsEvent onMoveEvent;
            public InputPhysicsEvent RotateTurret;
            public Slider healthSlider;
            public Animator animator;
            public GameObject Item1;
            public GameObject Item2;
            public GameObject Item3;
            public GameObject swordCollider;
            public GameObject swordCollider2;
            public GameObject HitBlood;
            public bool chackatt = false;

            public GameObject fxHide;
            public GameObject fxHp;
            public GameObject fxAtt;
            public AudioSource audioSource;
            public AudioClip audioClip;
            public Slider shieldSlider;
        

         
            void Start()
            {
               
                Debug.Log(" StringCoin");
            }
            void Update()
            {
               

                //-------------------------------------------------//
//                if (chackatt == true)
//                {
//                    Debug.Log("11");
//                    swordCollider.gameObject.SetActive(false);
//                }
//
               //--------------------------------------------------//             
//                Debug.Log(chackatt);


                //------------------------------------------------//
                if (PlayerPrefs.GetInt("HP") >= 1)
                {
                    Item1.gameObject.SetActive(true); 
                }

                else
                {
                    Item1.gameObject.SetActive(false);

                }

                //--------------------------------------------------//



                if (PlayerPrefs.GetInt("PowerAtt") >= 1)
                {
                    Item2.gameObject.SetActive(true);
                }
                else
                {
                    Item2.gameObject.SetActive(false);
                }

                //--------------------------------------------------//

                if (PlayerPrefs.GetInt("Hiden") >= 1)
                {
                    Item3.gameObject.SetActive(true);

                }
                else
                {
                    Item3.gameObject.SetActive(false);
                }

                //----------------------------------------------------//

                if (Input.GetKeyDown(KeyCode.C))
                {
                    onItemHPEvent.Invoke();
                }

                //------------------------------------------------------//

                if (Input.GetKey(KeyCode.X))
                {
                    onItemAttEvent.Invoke();
                }

                //---------------------------------------------------//

              // onCD.Invoke();

                if (Input.GetKey(KeyCode.Z))

                {
                    swordCollider.gameObject.SetActive(true);

                    animator.SetTrigger("Attack"); 

                    Invoke("AttDD", 1.05f);
                }
            }


            void FixedUpdate()
            {
                
                Vector2 moveDir;

               // Vector2 turnDir;
                //CrossPlatformInputManager
                if (CrossPlatformInputManager.GetAxisRaw("Horizontal") == 0 && CrossPlatformInputManager.GetAxisRaw("Vertical") == 0 &&CrossPlatformInputManager.GetAxisRaw("Horizontal_2") == 0 )
               
                {
                      moveDir.x = 0;
                      moveDir.y = 0;
                    animator.SetBool("on_Move",false);
                    GetComponent<AudioSource>().mute = true;

                }

                else
                {    
                    moveDir.x = CrossPlatformInputManager.GetAxis("Horizontal"); //LR
                    moveDir.y = CrossPlatformInputManager.GetAxis("Vertical");  //UpDown

                    if (moveDir.x == CrossPlatformInputManager.GetAxis("Horizontal"))
                    {
                        if (GetComponent<AudioSource>().mute)
                            GetComponent<AudioSource>().mute = false;
                           
                        animator.SetBool("on_Move", true);
                       // animator.SetBool("on_Chock", false);
              
                    }
                    onMoveEvent.Invoke(moveDir);
//                    else
//                    {
//                        animator.SetBool("on_Move", false);
//                    }

                   
                }



            }

           

            public void AttDD()
            {
                swordCollider.gameObject.SetActive(false);
            }
//           

//            public void AttDD(bool c)
//            {
//               
//                if (c == true)
//                {
//                    swordCollider.gameObject.SetActive(false);
//                }
//            }


            public void OnHealthChange(int hp,int maxHealth)
            {
                healthSlider.value = (float)hp / maxHealth;
            }



//
//            public void OnShieldChange(int value)
//            {
//                shieldSlider.value = value;
//            }

            public void OnSoundAtt()
            {
                audioSource.PlayOneShot(audioClip);
            }



            public void OnTriggerEnter(Collider coll)
            {
                onBulletEvent.Invoke(coll);
            }
    
           
           


        }
    }
}
