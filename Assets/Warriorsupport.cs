using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warriorsupport : MonoBehaviour
{
    private bool isIdle = true; //idle means no enemy in sight but may be still moving
    private bool stopped = false; //so this check if its moving even if its idle or not.
    //Another usage is that GameObject has to move back to the return point if its false

    public float speed = 1f; 
    public float range; // Tower range. Can't go further.
    
    public Transform returnPoint; //Return default position after encounter
    public Animator anim; //objects animator
    public Transform hedef; //GameObject to fight with.

    private bool hasTarget = false;
    public string enemyTag = "Enemy";

    // Start is called before the first frame update
    void Start()
    {
        returnPoint = transform.parent.GetChild(1).transform; //Return point has obtained.
        anim = transform.gameObject.GetComponent<Animator>(); //animator has obtained
        range = transform.parent.gameObject.GetComponent<SupTower>().range; //Tower range has obtained. 
        InvokeRepeating("FindTarget", 0f, 0.5f); //find target cycles twice per second
    }

    // Update is called once per frame
    void Update()
    {
        if (isIdle && !stopped) // is it Idle and still moving?
        {
            anim.SetBool("isIdle", false);
            Vector2 returnBack = returnPoint.position - transform.position;
            transform.Translate(returnBack.normalized * speed * Time.deltaTime, Space.World);
            if (Vector2.Distance(transform.position, returnPoint.position) <= 0.1f)
            {
                stopped = true;
                anim.SetBool("isIdle", true); //animat�rde idle kalacak
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed = 0;
        stopped = true;
        anim.SetBool("stopped", true);
        anim.SetBool("isIdle", false);
        InvokeRepeating("Duel", 0f, 1f);
    }
    void Duel()
    {
        Debug.Log("Yeaa we are duelling right now. WOW");
    }


















    // THIS PART SEARCHS FOR ENEMY
    void FindTarget()
    {
        if (hasTarget) 
        {
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestdistance = Mathf.Infinity; //E�er d��man bulunmam��sa d��mana olan mesafemiz sonsuzdur. nE!?!?
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)// find closest target 
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestdistance)
            {
                shortestdistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestdistance <= range)
        {
            hedef = nearestEnemy.transform; //if closest enemy is in range, its the target.
        }
        else
        {
            hedef = null;
        }
    }
}