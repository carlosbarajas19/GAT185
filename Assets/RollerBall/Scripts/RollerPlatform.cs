using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RollerPlatform : MonoBehaviour
{
    [SerializeField] Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            animator.SetTrigger("Activate");
        }
    }

}
