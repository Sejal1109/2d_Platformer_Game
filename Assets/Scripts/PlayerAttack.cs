using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerStats stats;
    public Animator animator;
    public Transform attackPoint;

    public int attackDamage;
    public float attackRange = 0.5f;

    public LayerMask enemyLayer;

    void Start() 
    {
        if (MainMenu.gameState == "New")
        { 
            attackDamage = SaveManager.instance.stats.attackDmg;
        }
        if (MainMenu.gameState == "Load")
        {
            attackDamage = SaveManager.instance.stats.attackDmg;
        }
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
}
