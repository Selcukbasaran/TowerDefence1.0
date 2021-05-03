using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_arrow : MonoBehaviour
{
    private Transform hedef;

    public float speed = 10f;

    public void Chase(Transform _target)
    {
        hedef = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (hedef == null)
        {
            Destroy(gameObject);
            return; // bazen yoketme zaman alabilir yok etmesini beklememiz lazým
        }

        Vector2 dir = hedef.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);

    }

    void HitTarget()
    {
        //Debug.Log("Vurdum!!");
        Destroy(gameObject);
    }
}
