using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    GameManager _gm;
    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.instance;
        _gm.current_level_path = this.gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
