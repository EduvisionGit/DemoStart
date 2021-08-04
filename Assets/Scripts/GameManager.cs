using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public GameObject current_level_path;
    public int currentScore = 0;
    public float base_enemy_speed;
    public Dictionary<int,(string,float)[]> levels;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.levels = Utilities.Levels.getLevels();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
