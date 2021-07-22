using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Troop : MonoBehaviour
{
    // Start is called before the first frame update
    double Timer = 0;
    double rate = 1.5;
    //default value (analogous to bpm)
    GameObject starterPos;
    int currentEnemyIndex = 0;
    Follower [] enemies;

    void Start()
    {
        starterPos = GameObject.Find("StartingPosition");
        GameObject enemiesUtil = GameObject.Find("Enemies");
        enemies =enemiesUtil.GetComponentsInChildren<Follower>();
        for(int i = 0;i<enemies.Length;i++){
            enemies[i].MakeIdle();
        }
        Debug.Log("All Enemies: " + enemies.Length.ToString());
    }
    // Update is called once per frame
    void Update()
    {
     if(enemies.Length == 0){
         return;
     }
     Timer+= Time.deltaTime;
     if(Timer>=rate){
         //Test: Instantiate enemy every 4 seconds
         Follower currentEnemy = enemies[currentEnemyIndex];
         Follower clone = Instantiate(currentEnemy,
            starterPos.transform.position, starterPos.transform.rotation 
         ) as Follower;
         Timer = 0;
         currentEnemyIndex++;
         currentEnemyIndex = currentEnemyIndex % enemies.Length;
     }   
    }
}
