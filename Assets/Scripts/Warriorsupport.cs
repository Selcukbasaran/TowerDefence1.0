using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warriorsupport : MonoBehaviour
{
    private bool isIdle = true; //idle means no enemy in sight but may be still moving
    private bool stopped = false; //so this check if its moving even if its idle or not.
    //Another usage is that GameObject has to move back to the return point if its false
    public bool opponentDead = false;
    Collider2D m_collider;

    public float speed = 1f; 
    public float range; // Tower range. Can't go further.
    private float yonHesabi;
    private bool facingRight = false;// this is to control if we are facing right way
    
    public Transform returnPoint; //Return default position after encounter
    public Animator anim; //objects animator
    public Transform hedef; //GameObject to fight with.

    private int Health;
    private bool alreadyDead = false;

    private bool hasTarget = false;
    public string enemyTag = "Enemy";
    public GameObject looseHealtForEnemy;

    // Start is called before the first frame update
    void Start()
    {
        returnPoint = transform.parent.GetChild(1).transform; //Return point has obtained.
        anim = transform.gameObject.GetComponent<Animator>(); //animator has obtained
        range = transform.parent.gameObject.GetComponent<SupTower>().range; //Tower range has obtained. 
        InvokeRepeating("FindTarget", 0f, 0.1f); //find target cycles twice per second
        m_collider = gameObject.GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Health = transform.gameObject.GetComponent<AdjustHealth>().Health;
        if (Health <= 0 && !alreadyDead)
        {
            CancelInvoke("Duel");
            alreadyDead = true;
            speed = 0;
            gameObject.layer = 13; //13. layer ölen birliklerin layerý
            anim.Play("WarriorDie");
            Destroy(gameObject, 1.7f);
            return;

        }
        if (isIdle && !stopped ) // is it Idle and still moving? 
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("stopped", false);
            Vector2 returnBack = returnPoint.position - transform.position;
            transform.Translate(returnBack.normalized * speed * Time.deltaTime, Space.World);
            if (Vector2.Distance(transform.position, returnPoint.position) <= 0.1f)
            {
                stopped = true;
                anim.SetBool("isIdle", true); //animatörde idle kalacak
                anim.SetBool("stopped", true);
            }
        }

        if (hedef == null) return;

        Vector2 directions = hedef.GetChild(0).transform.position - transform.position; //hedef ver
        transform.Translate(directions.normalized * speed * Time.deltaTime, Space.World);

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        speed = 0;
        stopped = true;
        anim.SetBool("stopped", true);
        anim.SetBool("isIdle", false);
        gameObject.layer = 30;  // Layer 30: Duels
        InvokeRepeating("Duel", 0f, 1f);
        Debug.LogWarning("Ben kaç kere triggerlýyorum?");
        looseHealtForEnemy = collision.gameObject;

        //Yön deðiþtirme
        yonHesabi = transform.position.x - collision.transform.position.x;

        if (yonHesabi > 0 && facingRight)
        {
            flipFace();
        }
        if (yonHesabi <= 0 && !facingRight)
        {
            flipFace();
        }
    }
    void Duel()
    {
        //Debug.Log("Yeaa we are duelling right now. WOW");
        new WaitForSecondsRealtime(.8f);
        looseHealtForEnemy.GetComponent<AdjustHealth>().LooseHealth(5);
        if (looseHealtForEnemy.GetComponent<AdjustHealth>().Health <= 0) opponentDead = true;
        if (opponentDead)
        {
            CancelInvoke("Duel");
            gameObject.layer = 11; // Layer 11:SupportTowerUnits
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        Debug.LogWarning("OnTriggerExit çalýþmýyor");
        CancelInvoke("Duel");
        anim.SetBool("isIdle", true);
        opponentDead = false;
        isIdle = true;
        stopped = false;
        speed = 1;
       
    }


    void flipFace()
    {
        facingRight = !facingRight;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }














    // THIS PART SEARCHS FOR ENEMY
    void FindTarget()
    {
        if (hasTarget) 
        {
            return;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestdistance = Mathf.Infinity; //Eðer düþman bulunmamýþsa düþmana olan mesafemiz sonsuzdur. nE!?!?
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
