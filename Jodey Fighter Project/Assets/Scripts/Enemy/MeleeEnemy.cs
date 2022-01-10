using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    [SerializeField] private float cooldownAttack;
    [SerializeField] private int damage;
    [SerializeField] private float boxColliderDistance;
    [SerializeField] private float range;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayerMask;

    private float cooldownTimer = Mathf.Infinity;
    private Animator animation;

    //Panggil PlayerHealth
    private Health playerHealth;

    //Panggil Enemy Patrol
    private PatrolEnemy enemyPatrol;



    private void Awake()
    {
        animation = GetComponent<Animator>();

        enemyPatrol = GetComponentInParent<PatrolEnemy>();
    }

    private void OnDisable()
    {
        //Menghentikan atau Destroy
        animation.SetBool("moving", false);

    }


    private void Update()
    {


        cooldownTimer += Time.deltaTime;

        if (PlayerInRange())
        {
            if (cooldownTimer >= cooldownAttack)
            {
                cooldownTimer = 0;
                animation.SetTrigger("meleeAttack");
            }
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInRange();


    }

    private bool PlayerInRange()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * boxColliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z)
            , 0, Vector2.left, 0, playerLayerMask);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * boxColliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void HurtingPlayer()
    {

        //Jika player masuk area musuh
        if (PlayerInRange())
        {

            playerHealth.takingHitDamage(damage);


        }
    }
}