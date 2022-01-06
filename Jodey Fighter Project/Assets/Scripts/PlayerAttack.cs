using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    private Animator animation;
    private PlayerMovement playerMovement;

    private float cooldownTime = Mathf.Infinity;


    private void Awake()
    {
        animation = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTime > attackCooldown && playerMovement.canAttack())
        Attacking();

        cooldownTime += Time.deltaTime;
    }

    private void Attacking()
    {
        animation.SetTrigger("attack");
        cooldownTime = 0;

    }
}
