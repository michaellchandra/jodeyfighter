using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    public float maxHealth = 5;
    public float currentHealth { get; private set; }
    private Animator animation;
    private bool dead;

    void Start()
    {
        currentHealth = maxHealth;
    }
    //void TakeDamage (int amount)
    //{
    //    currentHealth -= amount;

    //    if (currentHealth <= 0)
    //    {
    //        //Mati
    //        animation.SetTrigger("died");
    //        GetComponent<PlayerMovement>().enabled = false;
    //        dead = true;
    //    }
    //}

    //private void Awake()
    //{
    //    currentHealth = maxHealth;
    //    animation = GetComponent<Animator>();
    //}

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