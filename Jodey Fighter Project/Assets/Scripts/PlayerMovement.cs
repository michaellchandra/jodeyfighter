using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
    private Rigidbody2D body;
    private Animator animation;

    //Variabel Rigidbody dan Animator
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        //Balik Arah Player kiri kanan
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(-2, 2, 1);
        else if (horizontalInput == 0.00f)
            transform.localScale = new Vector3(-2, 2, 1);
        else if (horizontalInput < 0.01f)
            transform.localScale = new Vector3(2, 2, 1);


        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, speed);

        //Parameter Animator

        animation.SetBool("running", horizontalInput != 0);
    }

    
}
