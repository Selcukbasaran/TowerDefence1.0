using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum parts
{
     archer, wizard, archer_upgraded
}

public class SelectTower : MonoBehaviour
{
    private GameObject towerSelect;

    public GameObject archerTower;
    public GameObject wizardTower;
    public GameObject supportTower;
    public GameObject archerUpgraded;

    public Vector3 positionOffset_archer;
    public Vector3 positionOffset_wizard;

    private GameObject swap;
    private GameObject swap2;

    public void BuildTower(parts part)
    {
        switch (part)
        {
            case parts.archer:
                swap = (GameObject)Instantiate(archerTower, transform.position + positionOffset_archer, transform.rotation);
                swap.transform.parent = transform.parent;
                break;

            case parts.archer_upgraded:
                Destroy(swap);
                swap2 = (GameObject)Instantiate(archerUpgraded, transform.position + positionOffset_archer, transform.rotation);
                swap2.transform.parent = transform.parent;
                break;

            case parts.wizard:
                swap = (GameObject)Instantiate(wizardTower, transform.position + positionOffset_wizard, transform.rotation);
                swap.transform.parent = transform.parent;
                break;
        }
    }

    
}
