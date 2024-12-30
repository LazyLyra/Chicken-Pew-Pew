using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadcrumbScript : MonoBehaviour
{
    [SerializeField] float DeathTime;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathClock());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DeathClock()
    {
        yield return new WaitForSeconds(DeathTime);
        Destroy(gameObject);
    }
}
