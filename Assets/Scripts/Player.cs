using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [Range(0, 10)][Tooltip("Speed of the player")] public float speed = 5;
    [SerializeField] AudioSource audioSource;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.zero;

        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");

        transform.position += direction * speed * Time.deltaTime;
        //transform.localScale = new Vector3(2, 2, 2);
        
        if(Input.GetButtonDown("Fire1"))
        {
            GetComponent<Renderer>().material.color = Color.black;
            audioSource.Play();
            //transform.rotation *= Quaternion.Euler(5, 0, 0);
        }

        if (Input.GetButtonUp("Fire1"))
        {
            GetComponent<Renderer>().material.color = Color.white;
        }

        GameObject go = GameObject.Find("Cube");
        if(go != null)
        {
            go.GetComponent<Renderer>().material.color = Color.cyan;
        }
    }
}
