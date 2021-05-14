using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerBase : MonoBehaviour
{
    //renk verme
    [Header("Secim rengi")]
    public Color new_color;

    private SpriteRenderer spriteRenderer;
    //private Renderer rend;
    private Color startcolor;
    //renk verme bitiþ

    public GameObject towerSelect;
    private GameObject towerPick;
    private GameObject towerUpgrade;

    public Vector3 positionOffset_archer;
    public Vector3 positionOffset_wizard;

    public bool towerBuildable = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.material.color = Color.red;
        startcolor = spriteRenderer.material.color;
    }



    private void OnMouseDown()
    {
        if (transform.childCount != 0)
        {
            if(transform.GetChild(0).name == "OkcuKulesi(Clone)")
            {
                
                towerUpgrade = (GameObject)Instantiate(towerSelect, transform.position, transform.rotation);
                towerUpgrade.transform.parent = gameObject.transform;
                Destroy(transform.GetChild(0).gameObject);

            }


            
            Debug.Log("Zaten kule var! - TODO: Bu kýsým kullanýcý için ekrana yazýlsýn");
            return;
        }

        // Kule kurma
        //GameObject towerToBuild = TowerBuilder.instance.GetTowerToBuild();
        //tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset_wizard, transform.rotation);
        // Kule seçici deneme
        towerPick = (GameObject)Instantiate(towerSelect, transform.position,transform.rotation);
        towerPick.transform.parent = gameObject.transform;
        

    }
    


    void OnMouseEnter()
    {
        spriteRenderer.material.color = new_color;
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        spriteRenderer.material.color = startcolor;
        
    }


}
