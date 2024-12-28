using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
<<<<<<< HEAD
using System.Runtime.Serialization;
=======
>>>>>>> main
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] int MaxHealth;
    [SerializeField] int CurrentHealth;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======
>>>>>>> Stashed changes
<<<<<<< HEAD
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
=======
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
>>>>>>> main
>>>>>>> Stashed changes
=======
>>>>>>> main
>>>>>>> Stashed changes
    }
}
