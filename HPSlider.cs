using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TanksMP
{
    namespace View
    {
        
        public class HPSlider : MonoBehaviour
        {
            Slider healthBar;
            void Awake()
            {
             healthBar = GetComponent<Slider>();
            }

            // Use this for initialization
            void Start()
            {
		
            }
	
            // Update is called once per frame
            void Update()
            {
		
            }
            public void HpBarChange(int health)
                        {
                            //Debug.Log("Hello");
            
                            // Set the health bar's colour to proportion of the way between green and red based on the player's health.
                            healthBar.value = health;
            //
            //                // Set the scale of the health bar to be proportional to the player's health.
                            healthBar.transform.localScale = new Vector3(health * 0.01f, 1, 1);
                        }
        }

    }
}
