using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knight : MonoBehaviour
{
    private Animator animator;
    public float speed = 1f;

    private int Health;
    public GameObject looseHealth;
    public bool isIdle;
    public Rigidbody2D rb;
    Collider2D m_collider;
    private bool alreadyDead = false;

    private Transform target; // hedef waypoint
    private int waypointindex = 0; // kaçýncý waypointe hedefli

    public bool facingR = true; // saða bakýyor

    public GameObject looseHealtForEnemy;
    public bool opponentDead = false;
    void Start()
    {
        isIdle = true;
        target = Waypoints.waypoints[0];
        looseHealth = GameObject.Find("Gamemanager");
        animator = gameObject.GetComponent<Animator>();
        //InvokeRepeating("isDead", 0f, 0.2f); // saniyede iki defa öldü mü diye kontrol etsin
        transform.GetComponent<Rigidbody2D>();
        animator.SetBool("isIdle", true);
        m_collider = gameObject.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //transform.Translate(Vector2.down, Space.World);
        animator.SetBool("isIdle", false);
        speed = 0;
        gameObject.layer = 30;
        InvokeRepeating("Duel", 0f, 1.2f);
        looseHealtForEnemy = collision.gameObject;
    }
    void Duel()
    {
        //Debug.Log("Yeaa we are duelling right now. WOW");

        looseHealtForEnemy.GetComponent<AdjustHealth>().LooseHealth(7);
        if (looseHealtForEnemy.GetComponent<AdjustHealth>().Health <= 0) opponentDead = true;
        if (opponentDead)
        {
            CancelInvoke("Duel");
            //animator.SetBool("isIdle", true);
            //speed = 1;
            gameObject.layer = 10; // Layer 11:SupportTowerUnits
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        CancelInvoke("Duel");
        gameObject.layer = 10; // Layer 10: Enemy
        animator.SetBool("isIdle", true);
        speed = 1;

    }


    void Update()
    {
        if (alreadyDead) return;
        

        
        Health = transform.gameObject.GetComponent<AdjustHealth>().Health;
        if (Health <= 0)
        {
            alreadyDead = true;
            speed = 0;
            CancelInvoke("Duel");
            transform.gameObject.tag = "Untagged";
            gameObject.layer = 14; //99. layer ölen düþman birliklerin layerý
            m_collider.enabled = !(m_collider.enabled);
            //Debug.Log("Collider is " + m_collider.enabled);
            animator.Play("KnightDie");
            Destroy(gameObject, 1.7f);
            return;

        }
        

        Vector2 directions = target.position - transform.position; //hedef ver
        transform.Translate(directions.normalized * speed * Time.deltaTime, Space.World);

        if (directions.x < 0 && facingR)
        {
            flipface();
        }
        if (directions.x > 0 && !facingR)
        {
            flipface();
        }



        if (Vector2.Distance(transform.position, target.position) <= 0.1f)
        {
            GetNextWayp();
        }

    }

    void GetNextWayp()
    {
        if (waypointindex >= Waypoints.waypoints.Length - 1) //Sonuncu waypointe gelmiþse yok olsun.
        {
            looseHealth.GetComponent<Stats>().LooseGameHealth();
            Destroy(gameObject);
            return;
        }
        waypointindex++;
        target = Waypoints.waypoints[waypointindex];
    }

    void flipface()
    {
        facingR = !facingR;
        Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1;
        transform.localScale = tempLocalScale;
    }


    
}
