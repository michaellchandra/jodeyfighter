using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startHealth;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = startHealth;
    }

    public void takingHitDamage (float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startHealth);

        if (currentHealth > 0)
        {

        } 
        
        else
        {
            //Player Mati
        }
    }
}
