using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemyAI : MonoBehaviour
{
    public GameObject Player;
    public GameObject BC;
    public float Speed;
    private float Distance;
    [SerializeField] float FollowDistance;

    [Header("Following Info")]
    
    [SerializeField] bool LOSPlayer;
    [SerializeField] bool LOSBC;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        BC = GameObject.FindGameObjectWithTag("BreadCrumb");
     
    }

    // Update is called once per frame
    void Update()
    {

       
        if (LOSPlayer)
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

        else if (!LOSPlayer && LOSBC)
        {
            Distance = Vector2.Distance(transform.position, BC.transform.position);
            Vector2 direction = BC.transform.position - transform.position;
            direction.Normalize();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            if (Distance < FollowDistance)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, BC.transform.position, Speed * Time.deltaTime);
                transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            }
        }


    }

    private void FixedUpdate()
    {

        if (BC == null)
        {
            print("Empty");
            BC = GameObject.Find("Breadcrumb(Clone)");
        }

        RaycastHit2D rayplayer = Physics2D.Raycast(transform.position, Player.transform.position - transform.position);
        if (rayplayer.collider != null)
        {
            LOSPlayer = rayplayer.collider.CompareTag("Player");
            if (LOSPlayer)
            {
                Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, Player.transform.position - transform.position, Color.red);
            }
        }

        RaycastHit2D raybc = Physics2D.Raycast(transform.position, BC.transform.position - transform.position);
        if (raybc.collider != null)
        {
            LOSBC = raybc.collider.CompareTag("BreadCrumb");
            if (LOSBC)
            {
                Debug.DrawRay(transform.position, BC.transform.position - transform.position, Color.yellow);
            }
            else
            {
                Debug.DrawRay(transform.position, BC.transform.position - transform.position, Color.red);
            }
        }


    }
}
