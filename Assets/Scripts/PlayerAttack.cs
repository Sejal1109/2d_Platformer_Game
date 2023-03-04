using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;

    public int attackDamage = 12;
    public float attackRange = 0.5f;

    public LayerMask enemyLayer;

    void Start() 
    { 
    
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
    }

    void Attack() 
    {
        animator.SetTrigger("Attacking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies) 
        {
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void onDrawGizmosSelected() 
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
