using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;

    public float currentHealth;

    private Animator animation;
    private bool dead;



    private void Awake()
    {
        currentHealth = startHealth;
        animation = GetComponent<Animator>();
    }

    public void takingHitDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if (currentHealth > 0)
        {
            //Player kena damage
            animation.SetTrigger("hurt");
        }

        else
        {
            //Player Mati

            if (!dead)
            {
                animation.SetTrigger("died");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
            }

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            takingHitDamage(1);
    }
}
