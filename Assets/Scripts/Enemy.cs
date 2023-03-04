using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Animator anim = null;

    [SerializeField] public int dmgDealt = 10;

    public int maxHealth = 50;
    public int currentHealth;

    void Start() 
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int Damage) {
        
        currentHealth -= Damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else {

            anim.SetTrigger("Hit");
        }
    }

    void Die() {

        Debug.Log("Enemy Died!");
        anim.SetBool("Die", true);
        Invoke("DestroyObject", 1f);
        
    }

    void DestroyObject() 
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy Attack");
            anim.SetTrigger("attack");
        }
    }
}