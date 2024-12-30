using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedCollision : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] float knockBackDistance;
    [SerializeField] public int damage;
    public event EventHandler OnEnemyProjectileHit;

    public void OnCollisionEnter2D(Collision2D collision)
    {
     
        if (collision.gameObject.tag == "Player")
        {
            OnEnemyProjectileHit?.Invoke(this, EventArgs.Empty);
            gameObject.SetActive(false);
        }
    }

    public void knockBackHandling()
    {
        Vector2 Direction = player.transform.position - transform.position;
        Vector3 HorizontalMovement = new Vector2(Direction.x, 0);
        Vector3 VerticalMovement = new Vector2(0, Direction.y);
        player.transform.position += HorizontalMovement * knockBackDistance;
        player.transform.position += VerticalMovement;


    }
}
