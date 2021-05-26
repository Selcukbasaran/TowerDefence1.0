using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warriorsupport : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public string supportTag = "SupWarrior";

    public Transform hedef;
    public float speed = 1f;
    public float range = 5f;
    public Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestdistance = Mathf.Infinity; //Eðer düþman bulunmamýþsa düþmana olan mesafemiz sonsuzdur !?!?
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestdistance && hedef != null)
            {
                shortestdistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestdistance <= range)
        {
            hedef = nearestEnemy.transform;   //düþman bulduk menzilimizde o zaman hedefimiz o düþman
        }
        else
        {
            hedef = null;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //hedef = collision.gameObject;
            Debug.Log("EE çarpýþtýk tamam");
            //Destroy(collision.transform.gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Girdik.");
        //new WaitForSeconds(10000);
        transform.Translate(Vector2.up * speed * Time.deltaTime, Space.World);
    }


    // Update is called once per frame
    void Update()
    {
        if (hedef == null) return;

        Vector2 direction = hedef.position - transform.position;
        transform.Translate(direction.normalized + offset * speed * Time.deltaTime, Space.World);
        //Vector2 direction = hedef.transform.position - transform.position;
        //transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

    }
}
