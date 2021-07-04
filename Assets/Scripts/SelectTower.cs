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
    public GameObject stoneTower;

    public Vector3 positionOffset_archer;
    public Vector3 positionOffset_wizard;

    private GameObject swap;
    //private GameObject swap2;
    private GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    void OnMouseExit()
    {
        Destroy(gameObject);
    }

    public bool AdjustGold(int value)
    {
        return gameManager.GetComponent<Stats>().MinusGold(value);
    }
    public void BuildTower(parts part)
    {
        switch (part)
        {
            case parts.archer:
                if (AdjustGold(100))
                {
                    
                }
                swap = (GameObject)Instantiate(archerTower, transform.position + positionOffset_archer, transform.rotation);
                swap.transform.parent = transform.parent;
                
                break;

            case parts.wizard:
                swap = (GameObject)Instantiate(wizardTower, transform.position + positionOffset_wizard, transform.rotation);
                swap.transform.parent = transform.parent;
                AdjustGold(100);
                break;

            case parts.support:
                swap = (GameObject)Instantiate(supportTower, transform.position + positionOffset_wizard, transform.rotation);
                swap.transform.parent = transform.parent;
                AdjustGold(100);
                break;
            case parts.stone:
                swap = (GameObject)Instantiate(stoneTower, transform.position + positionOffset_archer, transform.rotation);
                swap.transform.parent = transform.parent;
                AdjustGold(100);
                break;
        }
    }

    

    
}
