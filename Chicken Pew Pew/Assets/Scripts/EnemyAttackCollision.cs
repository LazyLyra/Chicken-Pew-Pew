using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttackCollision : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] float knockBackDistance;
    [SerializeField] public int damage;
    public event EventHandler OnEnemyHit;

    private void OnTriggerEnter2D(Collider2D colllision)
    {
        if (colllision.gameObject.tag == "Player")
        {
            OnEnemyHit?.Invoke(this, EventArgs.Empty);
        }
    }


    private float rotateSpeed = 2f;
    public void knockBackHandling()
    {
        Vector2 Direction = player.transform.position - enemy.transform.position;
        Vector3 HorizontalMovement = new Vector2(Direction.x, 0);
        Vector3 VerticalMovement = new Vector2(0, Direction.y);
        player.transform.position += HorizontalMovement * knockBackDistance;
        player.transform.position += VerticalMovement;
        

    }
 
}
