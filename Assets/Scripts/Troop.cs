using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;
public class Troop : MonoBehaviour
{
    
    //Music Management
    public float songBpm;
    //for la campanella (may want to assign bpm based on song in better way)
    public float secPerBeat;
    public float songPosition;
    public float songPositionInBeats;
    public float dspSongTime;
    public float firstBeatOffset = 5.0f;
    public AudioSource musicSource;


    double Timer = 0;
    [SerializeField] GameObject starterPos;
    int level = 1;
    (string, float) enemyAndSpawnTime;
    int currentEnemyIndex = 0;
    [SerializeField] private Follower template;
    GameObject path;
    GameManager _gm;
    void Start()
    {
        _gm = GameManager.instance;
        path = _gm.current_level_path;
        template.MakeIdle();
        enemyAndSpawnTime = _gm.levels[level][currentEnemyIndex];
        //Music
        secPerBeat = 60f / songBpm;
        _gm.base_enemy_speed = secPerBeat;
         musicSource = GetComponent<AudioSource>();
        dspSongTime = (float)AudioSettings.dspTime;
        musicSource.Play(); 
    }
    // Update is called once per frame
    void Update()
    {
        //Music
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);
        songPositionInBeats = songPosition / secPerBeat;
        if (currentEnemyIndex == _gm.levels[level].Length-1)
        {
            return;
        }
        Timer += Time.deltaTime;
        if (Timer >= enemyAndSpawnTime.Item2)
        {
            Enemy EnemyType = Utilities.EnemiesManager.getEnemy(enemyAndSpawnTime.Item1);
            Follower clone = Instantiate(template,
               starterPos.transform.position, starterPos.transform.rotation
            ) as Follower;
            clone.setUp(EnemyType.getHp(), EnemyType.getColor(), path, _gm.base_enemy_speed * EnemyType.getSpeedFactor());
            //next enemy and spawn time
            currentEnemyIndex++;
            enemyAndSpawnTime = _gm.levels[level][currentEnemyIndex];
        }
    }
}
