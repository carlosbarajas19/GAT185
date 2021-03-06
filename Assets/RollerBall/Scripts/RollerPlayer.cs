using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RollerPlayer : MonoBehaviour, IDestructable
{
    [SerializeField] float maxForce = 5;
    [SerializeField] float jumpForce = 5;
    [SerializeField] ForceMode forceMode;
    [SerializeField] Transform viewTransform;

    public int maxJumps = 2;
    public int countJumps { get; set; } = 0;
    public bool canJump { get; set; } = true;
    Rigidbody rb;
    Vector3 force = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        Quaternion viewSpace = Quaternion.AngleAxis(viewTransform.rotation.eulerAngles.y, Vector3.up);
        direction = viewSpace * direction;

        //world space
        force = direction * maxForce;

        if(Input.GetButtonDown("Jump") && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            countJumps++;
            if (countJumps >= maxJumps) canJump = false;
        }
       

        RollerGameManager.Instance.playerHealth = GetComponent<Health>().health;

    }

    private void FixedUpdate()
    {
        rb.AddForce(force, forceMode);
        
    }

    public void Destroyed()
    {
        RollerGameManager.Instance.OnPlayerDead();
    }
}
