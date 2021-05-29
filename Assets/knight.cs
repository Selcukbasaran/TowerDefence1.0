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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        animator.SetBool("isIdle", true);
        if (!alreadyDead) speed = 1f;
    }

    void Update()
    {
        Health = transform.gameObject.GetComponent<AdjustHealth>().Health;
        if (Health <= 0 && !alreadyDead)
        {
            alreadyDead = true;
            transform.gameObject.tag = "Untagged";
            m_collider.enabled = !(m_collider.enabled);
            Debug.Log("Collider is " + m_collider.enabled);
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
