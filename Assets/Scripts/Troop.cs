using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class Troop : MonoBehaviour
{
    // Start is called before the first frame update
    double Timer = 0;
    double rate = 1.5;
    //default value (analogous to bpm)
    GameObject starterPos;
    string[] enemies = {
        "red", "red", "red", "red",
        "yellow", "yellow", "yellow",
        "green", "green", "green", "green",
        "green"
    };
    int currentEnemyIndex = 0;
    [SerializeField] private Follower template;
    void Start()
    {
        template.MakeIdle();
        starterPos = GameObject.Find("StartingPosition");
    }
    // Update is called once per frame
    void Update()
    {
        if (currentEnemyIndex == enemies.Length - 1)
        {
            return;
        }
        Timer += Time.deltaTime;
        if (Timer >= rate)
        {
            //Test: Instantiate enemy every 4 seconds
            Enemy EnemyType = Utilities.EnemiesManager.getEnemy(enemies[currentEnemyIndex]);
            Follower clone = Instantiate(template,
               starterPos.transform.position, starterPos.transform.rotation
            ) as Follower;
            clone.setUp(EnemyType.getHp(), EnemyType.getColor());
            Timer = 0;
            currentEnemyIndex++;
            currentEnemyIndex = currentEnemyIndex % enemies.Length;
        }
    }
}
