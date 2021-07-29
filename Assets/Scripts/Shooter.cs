using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    GameManager _gm;

    [SerializeField] private Bullet base_bullet;

    public float waveLength = 3f;
    public float frequency = 2f;


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
            Bullet curBullet = Instantiate(base_bullet, this.transform);
            curBullet.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 0);
            curBullet.SetSpeed(frequency * waveLength);
            curBullet.ShootBullet(this.transform.up);
        }


    }
}
