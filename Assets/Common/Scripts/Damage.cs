using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = 0;
    [SerializeField] string ignoreTag;
    [SerializeField] bool oneTime = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!oneTime) return;
        if (other.tag == ignoreTag) return;
        if(other.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Damage(damage);
        }
/*        if(gameObject.TryGetComponent<Health>(out health) && other.gameObject.TryGetComponent<Damage>(out Damage otherDamage))
        {
            health.Damage(otherDamage.damage);
        }*/
    }

    private void OnTriggerStay(Collider other)
    {
        if (oneTime) return;
        if (other.tag == ignoreTag) return;

        if (other.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Damage(damage * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!oneTime) return;
        if (other.gameObject.tag == ignoreTag) return;
        if (other.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Damage(damage);
        }
    }
}
