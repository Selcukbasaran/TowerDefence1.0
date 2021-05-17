using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum parts
{
     archer, archer2, archer3, wizard, wizard2, wizard3, support, support2, support3, stone, stone2, stone3
}


public class SelectTower : MonoBehaviour
{
    private GameObject towerSelect;

    public GameObject archerTower;
    public GameObject wizardTower;
    public GameObject supportTower;

    public Vector3 positionOffset_archer;
    public Vector3 positionOffset_wizard;

    private GameObject swap;
    //private GameObject swap2;

    void OnMouseExit()
    {
        Destroy(gameObject);
    }


    public void BuildTower(parts part)
    {
        switch (part)
        {
            case parts.archer:
                swap = (GameObject)Instantiate(archerTower, transform.position + positionOffset_archer, transform.rotation);
                swap.transform.parent = transform.parent;
                break;


            case parts.wizard:
                swap = (GameObject)Instantiate(wizardTower, transform.position + positionOffset_wizard, transform.rotation);
                swap.transform.parent = transform.parent;
                break;

            case parts.support:
                swap = (GameObject)Instantiate(supportTower, transform.position + positionOffset_wizard, transform.rotation);
                swap.transform.parent = transform.parent;
                break;
        }
    }

    

    
}
