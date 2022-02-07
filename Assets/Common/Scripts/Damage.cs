using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 0;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Damage(damage);
        }
/*        if(gameObject.TryGetComponent<Health>(out health) && other.gameObject.TryGetComponent<Damage>(out Damage otherDamage))
        {
            health.Damage(otherDamage.damage);
        }*/
    }
}
