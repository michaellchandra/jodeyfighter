using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jump_power;
    private Rigidbody2D body;
    private Animator animation;
    private BoxCollider2D boxCollider;
    private float jumpWallCooldown;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;



    //Variabel Rigidbody dan Animator
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        


        //Balik Arah Player kiri kanan
        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(-2, 2, 1);
        else if (horizontalInput == 0.00f)
            transform.localScale = new Vector3(-2, 2, 1);
        else if (horizontalInput < 0.01f)
            transform.localScale = new Vector3(2, 2, 1);


        //Parameter Animator

        animation.SetBool("running", horizontalInput != 0);
        animation.SetBool("grounded", isGrounded());

        //Lompat ke Wall

        if (jumpWallCooldown < 0.3f)
        {
           

            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (onWall() && !isGrounded()){
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }

            else
            {
                body.gravityScale = 3;
            }

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
        {
            jumpWallCooldown += Time.deltaTime;
        }
    }

    private void Jump()
    {
        if (isGrounded())
        {
            animation.SetTrigger("jump");
            body.velocity = new Vector2(body.velocity.x, jump_power);
        }

        else if (onWall() && !isGrounded())
        {

        }

        if (Input.GetKey(KeyCode.Space))
            Jump();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Ground")
        //    grounded = true;
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

}
