using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private GameObject child;
    [SerializeField] float attackTime;


    // Start is called before the first frame update
    void Start()
    {
        child = transform.GetChild(0).gameObject;
        child.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 Direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = Direction;

        if (Input.GetMouseButtonDown(0))
        {
            
            StartCoroutine(AttackStart());
        }
    }

   private IEnumerator AttackStart()
    {
        child.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        child.SetActive(false);
    }
}
