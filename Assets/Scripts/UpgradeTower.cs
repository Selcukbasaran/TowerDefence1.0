using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTower : MonoBehaviour
{
    public GameObject archer2;
    public GameObject archer3;
    public GameObject wizard2;
    public GameObject wizard3;

    public Vector3 positionOffset_archer;
    public Vector3 positionOffset_wizard;

    private GameObject swap;

    public void UpgradeT(parts part)
    {
        switch (part)
        {
            case parts.archer:
                Destroy(transform.parent.GetChild(0).gameObject);
                swap = (GameObject)Instantiate(archer2, transform.position + positionOffset_archer, transform.rotation);
                swap.transform.parent = transform.parent;
                break;

            case parts.archer2:
                Destroy(transform.parent.GetChild(0).gameObject);
                swap = (GameObject)Instantiate(archer3, transform.position + positionOffset_archer, transform.rotation);
                swap.transform.parent = transform.parent;
                break;

            case parts.archer3:
                Debug.Log("Kule zaten son seviyede! Yükseltme yapýlamaz.");
                break;

            case parts.wizard:
                Destroy(transform.parent.GetChild(0).gameObject);
                swap = (GameObject)Instantiate(wizard2, transform.position + positionOffset_archer, transform.rotation);
                swap.transform.parent = transform.parent;
                break;

            case parts.wizard2:
                Destroy(transform.parent.GetChild(0).gameObject);
                swap = (GameObject)Instantiate(wizard3, transform.position + positionOffset_archer, transform.rotation);
                swap.transform.parent = transform.parent;
                break;

            case parts.wizard3:
                Debug.Log("Kule zaten son seviyede! Yükseltme yapýlamaz.");
                break;
        }
    }
}
