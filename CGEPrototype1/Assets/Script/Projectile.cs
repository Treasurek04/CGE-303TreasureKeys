using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Rigidbody2D rb; 

    public float speed = 20f;

    public int damage = 20; 

    // Start is called before the first frame update
    void Start()

    {
        //Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();

        //Set the velocity of the projectile to fire to the right at the speed
        rb.velocity = transform.right * speed;  
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if(enemy != null )
        {
            enemy.TakeDamage( damage );
        }

        if(hitInfo.gameObject.tag != "Player")
        {
            Destroy(getObject);
        }
    }
}

