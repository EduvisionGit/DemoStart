using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Bullet : MonoBehaviour
{

    [SerializeField]private float speed;
    private bool bulletFired;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootBullet(Vector3 direct)
    {
        Debug.Log(direct);
        //rb.velocity = direct * speed;
        rb.AddForce(direct * speed*50);
    }

    public void SetSpeed(float sp)
    {
        speed = sp; 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            Destroy(this.gameObject);
        }
    }

}
