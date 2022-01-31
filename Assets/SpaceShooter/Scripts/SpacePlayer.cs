using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacePlayer : MonoBehaviour, IDestructable
{
    [Range(0, 200)] [Tooltip("Speed of the player")] public float speed = 5;

    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        transform.Translate(direction * speed * Time.deltaTime);
        //transform.position += direction * speed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            GetComponent<SpaceWeapon>().Fire();
        }

        GameManager.Instance.playerHealth = GetComponent<Health>().health;

    }

    public void Destroyed()
    {
        GameManager.Instance.playerHealth = 0;
        GameManager.Instance.OnPlayerDead();    
    }
}
