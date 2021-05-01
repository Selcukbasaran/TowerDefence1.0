using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardWalk : MonoBehaviour
{

    public float speed = 5f;

    private Transform target; // hedef waypoint
    private int waypointindex = 0; // ka��nc� waypointe hedefli

    public bool facingR = true; // sa�a bak�yor

    void Start()
    {
        target = Waypoints.waypoints[0];
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
        if (waypointindex >= Waypoints.waypoints.Length-1) //Sonuncu waypointe gelmi�se yok olsun.
        {
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
