using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] int MaxHP;
    [SerializeField] int CurrentHP;

    [Header("Attack")]
    [SerializeField] int AttackDamage;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int DamageReceived)
    {
        CurrentHP = CurrentHP - DamageReceived;
        if (CurrentHP <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {

    }

    public void Die()
    {
        GameObject.Destroy(gameObject);
    }
}
