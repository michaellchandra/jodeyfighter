using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTraps : MonoBehaviour
{

    [SerializeField]private float damaged;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().takingHitDamage(damaged);
        }
    }

}
