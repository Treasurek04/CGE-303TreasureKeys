using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPlayerController : MonoBehaviour
{
    public float speed;

    public float turnSpeed;

    public float horizontalInput;
    public float verticalInput;

    private Vector3 currentDirection = Vector3.zero; 

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector2.right * Time.deltaTime * speed * verticalInput);

        //transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);
        if (verticalInput < 0 )
        {
            transform.Rotate(Vector3.back, -turnSpeed * Time.deltaTime * horizontalInput); 

        }
        else
        {
            transform.Rotate(Vector3.back, turnSpeed * Time.deltaTime * horizontalInput);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        currentDirection = Vector3.zero;
        this.GetComponent<Rigidbody2D>().velocity = Vector3.zero; 
    }
}

