using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceDirectionMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction;
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
