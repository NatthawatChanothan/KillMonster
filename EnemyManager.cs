using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour {

    public GameObject[] enemy;
    public Transform[] spawnPoints;
    public palinee.Path[] Path;

	
	void Start () 
    {
//        Spawn();
        StartCoroutine("Spawn");
		
	}
	
	
	void Update () 
    {
		
	}

    IEnumerator Spawn()
    {
        for (int i = 1 ; i <= 4; i++)
        {
            
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            GameObject em = (GameObject)Instantiate(enemy[0], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
           
            em.GetComponent<palinee.AiFsm>().path = Path[spawnPointIndex];
            yield return new WaitForSeconds(7);
           
        }
    }

//    IEnumerator DelaySpawn()
//    {
//        yield return new WaitForSeconds(10);
//    }


}
