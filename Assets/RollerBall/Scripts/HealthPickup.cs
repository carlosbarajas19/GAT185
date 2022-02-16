using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup, IDestructable
{
    [SerializeField] int health;
    public void Destroyed()
    {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        go.GetComponent<Health>().health += health;

    }
}
