using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{

    public static TowerBuilder instance; //kendi referans� ve buna her yerden ula��caz

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Birden fazla builder olamaz");
            return;
        }
        instance = this; // tek builder bu olacak
        
    }

    public GameObject towerPrefab;

    private void Start()
    {
        towerToBuild = towerPrefab;
    }

    private GameObject towerToBuild;

    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }

}
