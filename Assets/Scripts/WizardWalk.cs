using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardWalk : MonoBehaviour
{

    public float speed = 5f;

    public int wizHealth = 20; //büyücü caný
    public GameObject looseHealth;

    private Transform target; // hedef waypoint
    private int waypointindex = 0; // kaçýncý waypointe hedefli

    public bool facingR = true; // saða bakýyor

    void Start()
    {
        target = Waypoints.waypoints[0];
        looseHealth = GameObject.Find("Gamemanager");
    }

    
    void Update()
    {
        Vector2 directions = target.position - transform.position; //hedef ver
        transform.Translate(directions.normalized * speed * Time.deltaTime, Space.World);

        if(directions.x < 0 && facingR)
        {
            flipface();
        }
        if(directions.x > 0 && !facingR)
        {
            flipface();
        }

        if(Vector2.Distance(transform.position,target.position)<= 0.1f)
        {
            GetNextWayp();
        }

    }

    void GetNextWayp()
    {
        if (waypointindex >= Waypoints.waypoints.Length-1) //Sonuncu waypointe gelmiþse yok olsun.
        {
            looseHealth.GetComponent<GameManager>().LooseHealth();
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
