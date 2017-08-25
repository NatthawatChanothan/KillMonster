using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace TanksMP
{
    namespace Model
    { 
        [System.Serializable]
        public class HpEvent : UnityEvent<int,int>{}
        [System.Serializable]
        public class ShieldEvent : UnityEvent<int>{}

        public class PlayerModel : MonoBehaviour
        {
            public bool invisible;
            public float m_MoveSpeed = 10f;
            [HideInInspector]
            public short turretRotation;
            public int maxHealth = 20;
            public int hp ;
            public int shield = 6;
            public int GetShield;
            public int Damage = 1;
            public int dm = 3; //present // Max DM
            public float speedRotation = 150f;
            public float moveRotaion = 6;
            public MeshRenderer[] renderers;

            public Transform turret;
            public Transform shotPos;
    

            public HpEvent onHealthChangedEvents;
            public ShieldEvent onshieldSliderEvents;

            [HideInInspector]
            public int time;

            [HideInInspector]
            public int maxTime;

    
            void Update()
            {
               
            }
            private SphereCollider m_Collider;
            public GameObject textMsg;



//            public float Radius
//            {
//                get
//                {
//                    return m_Collider.radius;
//                }
//            }
//

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


            void Awake()
            {
                m_Collider = GetComponent<SphereCollider>();
            }

            void Start()

                {  
//                camFollow = Camera.main.GetComponent<FollowTarget>();
//                camFollow.target = turret;
                  
                }

//            void Updete()
//            {
//                GetShield = shield;
//
//            }



            public  int Health
            {
                
                get 
                { 
                    return hp; 
                }


                set 
                { 
                    hp = value;

                    if (hp > maxHealth)
                        hp = maxHealth;
                    onHealthChangedEvents.Invoke(value,maxHealth); 
                }

            }


//
//            public int Shield
//            {
//                
//                get 
//                { 
//                    return shield; 
//                }
//
//                set 
//                { 
//                    shield = value;
//                    onshieldSliderEvents.Invoke(value); 
//                }
//
//            }
        }
    }
}