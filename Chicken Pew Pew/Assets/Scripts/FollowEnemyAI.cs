using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyAI : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    private float Distance;
    [SerializeField] float FollowDistance;

    [Header("Following Info")]
    [SerializeField] bool Pursuing;
    [SerializeField] bool Idle;
    [SerializeField] bool LOS;
    // Start is called before the first frame update
    void Start()
    {
        Idle = true;
        Pursuing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LOS)
        {
            Distance = Vector2.Distance(transform.position, Player.transform.position);
            Vector2 direction = Player.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (Distance < FollowDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, Player.transform.position - transform.position);
        if (ray.collider != null)
        {
            LOS = ray.collider.CompareTag("Player");
            if (LOS)
            {
                Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.red);
            }
        }
        
        
    }
}
