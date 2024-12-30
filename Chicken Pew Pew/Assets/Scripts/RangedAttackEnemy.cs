using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class RangedAttackEnemy : MonoBehaviour
{

    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject PooShot;
    [SerializeField] FollowEnemyAI followEnemyAI;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float coolDownTimer;
    private float initialTimer;
    private float existentialTimer;
    private bool pooIsMoving;
    private Vector3 fixedDirection;
    private void Start()
    {
        initialTimer = coolDownTimer;
        existentialTimer = initialTimer - 1;
    }
    void Update()
    {

        if (coolDownTimer <= 0 && followEnemyAI.attacking)
        {
            StartCoroutine(visualHandling());
            PooShot.transform.position = enemy.transform.position;
            Vector2 Direction = player.transform.position - enemy.transform.position;
            fixedDirection = Direction;
            coolDownTimer = initialTimer;
        }
        else
        {
            coolDownTimer -= Time.deltaTime;
        }
        if (pooIsMoving) 
        {

            PooShot.transform.position += fixedDirection * projectileSpeed * Time.deltaTime;
        }

    }

    private IEnumerator visualHandling()
    {
        PooShot.SetActive(true);
        pooIsMoving = true;
        yield return new WaitForSeconds(existentialTimer);
        PooShot.SetActive(false);
        pooIsMoving = false;
        existentialTimer = initialTimer - 1;

    }


}
