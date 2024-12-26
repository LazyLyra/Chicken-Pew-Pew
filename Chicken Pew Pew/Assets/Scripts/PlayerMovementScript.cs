using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float MoveSpeed;
    public Rigidbody2D RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 HorizontalInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        Vector3 HorizontalMovement = HorizontalInput * MoveSpeed * Time.deltaTime;
        transform.position = transform.position + HorizontalMovement;

        Vector3 VerticalInput = new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
        Vector3 VerticalMovement = VerticalInput * MoveSpeed * Time.deltaTime;
        transform.position = transform.position + VerticalMovement;

        
    }

}
