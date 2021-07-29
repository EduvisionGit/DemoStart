using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    GameManager _gm;


    // Start is called before the first frame update
    void Start()
    {
        _gm = GameManager.instance;  // Gets refernce to game manager instance(which we know exists)

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Print and update score attribute in GameManager instance
        {
            Debug.Log(_gm.currentScore); 
            _gm.currentScore++; 
        }
    }
}
