using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAim : MonoBehaviour
{
    [SerializeField] PlayerMovementScript playerMovementScript;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject attackRegion;
    [SerializeField] float coolDownTimer;
    [SerializeField] float attackTime;
   



    private void Update()
    {
        Vector3 playerPosition = playerMovementScript.transform.position;
        Vector2 Direction = playerPosition - enemy.transform.position;
        if (Direction.magnitude > 0.5f)
        {
            transform.up = Direction;
        }
        else
        {
            if(coolDownTimer<= 0)
            { 
                StartCoroutine(visualHandling());
                coolDownTimer = 0.6f;
            }

        }
        coolDownTimer -= Time.deltaTime;
    }
    private IEnumerator visualHandling()
    {
        attackRegion.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        attackRegion.SetActive(false);

    }
}   
