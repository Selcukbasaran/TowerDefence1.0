using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustHealth : MonoBehaviour
{
    public int Health;

    public void LooseHealth(int n)
    {
        Health -= n;
    }
}
