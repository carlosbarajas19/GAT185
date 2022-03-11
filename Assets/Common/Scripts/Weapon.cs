using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    [SerializeField] string activeAnimation;
    [SerializeField] string actionAnimation;
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] Transform spawnTransform;

    public override void Activate()
    {
        visual.SetActive(true);
        if (!string.IsNullOrEmpty(activeAnimation)) animator.SetBool(activeAnimation, true);

    }

    public override void Deactivate()
    {
        visual.SetActive(false);
        if (!string.IsNullOrEmpty(activeAnimation)) animator.SetBool(activeAnimation, false);
    }

    public override void UpdateItem()
    {
        if (Input.GetButtonDown(input)) 
            StartFire();
        if (Input.GetButtonUp(input)) StopFire();
    }

    private void StartFire()
    {
        animator.SetBool(actionAnimation, true);
    }

    private void StopFire()
    {
        animator.SetBool(actionAnimation, false);
    }



    public void Fire()
    {
        Instantiate(ammoPrefab, spawnTransform.position, spawnTransform.rotation);
    }
}
