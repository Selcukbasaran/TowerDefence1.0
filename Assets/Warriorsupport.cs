using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warriorsupport : MonoBehaviour
{
    public string enemyTag = "Enemy";
    public string supportTag = "SupWarrior";
    // Start is called before the first frame update
    void Start()
    {
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
