using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != 8) return;
        if(gameObject.transform.parent.gameObject.TryGetComponent<RollerPlayer>(out RollerPlayer player))
        {
            player.canJump = true;
            player.countJumps = 0;
        }
    }
}
