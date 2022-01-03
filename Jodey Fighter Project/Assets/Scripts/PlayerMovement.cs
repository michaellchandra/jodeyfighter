using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<RigidBody2D>();
    }

    private void Update()
    {
        body.velocity = new Vector3(Input.GetAxis("Horizontal"), body.velocity.y, body.velocity.z);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
