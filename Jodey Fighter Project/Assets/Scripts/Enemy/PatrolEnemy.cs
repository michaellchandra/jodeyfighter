using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    [Header ("Patrol Points")] 

    [SerializeField] private Transform goingLeft;
    [SerializeField] private Transform goingRight;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Speed")]
    [SerializeField] private float enemySpeed;

    [Header("Enemy Animation")]
    [SerializeField] private Animator animation;
    private float idlingTimer;


    [SerializeField]private float enemyIdlingDuration;


    private Vector3 initScale;

    private bool moveToLeft;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (moveToLeft)
        {
            if (enemy.position.x >= goingLeft.position.x)
                MovingDirection(-1);
            
            else
                ChangeDirection();
            

        }
        else
        {
            if (enemy.position.x <= goingRight.position.x)
                MovingDirection(1);
            

            else
                ChangeDirection();
            
        }

    }

    private void MovingDirection (int _direction)
    {

        idlingTimer = 0;
        animation.SetBool("moving", true);

        //Arah penglihatan atau Wajah Musuh
        enemy.localScale = new Vector3(Mathf.Abs (initScale.x) * _direction, initScale.y, initScale.z);

        //Arah jalan musuh
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * enemySpeed,
            enemy.position.y, enemy.position.z);

    }

    

    private void ChangeDirection()
    {
        animation.SetBool("moving", false);

        idlingTimer += Time.deltaTime;

        if(idlingTimer > enemyIdlingDuration)
            moveToLeft = !moveToLeft;
    }
}
