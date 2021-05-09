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
    //renk verme biti�

    private GameObject tower;

    public Vector3 positionOffset;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.material.color = Color.red;
        startcolor = spriteRenderer.material.color;
    }



    private void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Zaten kule var! - TODO: Bu k�s�m kullan�c� i�in ekrana yaz�ls�n");
            return;
        }

        // Kule kurma
        GameObject towerToBuild = TowerBuilder.instance.GetTowerToBuild();
        tower = (GameObject)Instantiate(towerToBuild, transform.position + positionOffset, transform.rotation);

    }


    void OnMouseEnter()
    {
        spriteRenderer.material.color = new_color;
        Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        spriteRenderer.material.color = startcolor;
    }


}