using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
    private Rigidbody2D body;
    private Animator animation;
    private bool grounded;

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


        if (Input.GetKey(KeyCode.Space) && grounded)
            Jump();
        

        //Parameter Animator

        animation.SetBool("running", horizontalInput != 0);
        animation.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

}
