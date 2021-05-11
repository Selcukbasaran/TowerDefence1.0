using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum parts
{
     archer, wizard, body
}

public class SelectTower : MonoBehaviour
{
    private GameObject towerSelect;

    public GameObject archerTower;
    public GameObject wizardTower;
    public GameObject supportTower;

    public Vector3 positionOffset_archer;
    public Vector3 positionOffset_wizard;

    public void BuildTower(parts part)
    {
        switch (part)
        {
            case parts.archer:
                Instantiate(archerTower, transform.position + positionOffset_archer, transform.rotation);
                
                break;
            case parts.wizard:
                Instantiate(wizardTower, transform.position + positionOffset_wizard, transform.rotation);
                break;
        }
    }

    
}
