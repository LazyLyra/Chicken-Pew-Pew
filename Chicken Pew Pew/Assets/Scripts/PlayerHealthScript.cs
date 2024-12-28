using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int MaxHealth;
    [SerializeField] int CurrentHealth;
    // Start is called before the first frame update
    [SerializeField] EnemyAttackCollision enemyAttackCollision;
    [SerializeField] GameObject player;
    [SerializeField] GameObject attackRegion;




    // Start is called before the first frame update
    void Start()
    {
        enemyAttackCollision.OnEnemyHit += EnemyAttackCollision_OnEnemyHit;
    }

    private void EnemyAttackCollision_OnEnemyHit(object sender, System.EventArgs e)
    {
        enemyAttackCollision.knockBackHandling();
        TakeDamage(enemyAttackCollision.damage);

    }
    private void TakeDamage(int damageReceived)
    {
        CurrentHealth -= damageReceived;
        if (CurrentHealth < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject.Destroy(gameObject);
    }
}