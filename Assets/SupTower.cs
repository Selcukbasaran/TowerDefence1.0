using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupTower : MonoBehaviour
{
    public GameObject warrior;
    public Transform origin;
    

    public float countDown;
    public float range;



    public string enemyTag = "Enemy";
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount < 3)
        {
            warrior = (GameObject)Instantiate(warrior, origin.position, origin.rotation);
            warrior.transform.parent = transform;
        }   
    }

    
    
}
