using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] AudioClip pickupSound;
    public float amplitude;
    public float rate;
    public float spinRate;

    Vector3 initialPosition;
    float time;
    float angle;

    void Start()
    {
        //time = Random.Range(0.0f, 5.0f);
        //angle = Random.Range(0f, 360f);

        initialPosition = transform.position;

    }


    void Update()
    {
        time += Time.deltaTime * rate;
        angle += Time.deltaTime * spinRate;

        Vector3 offset = Vector3.up * Mathf.Sin(time) * amplitude;// new Vector3(0, Mathf.Sin(time) * amplitude, 0);
        transform.position = initialPosition + offset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(pickupSound != null) AudioSource.PlayClipAtPoint(pickupSound, transform.position);
            if (TryGetComponent<IDestructable>(out IDestructable destructable))
            {
                destructable.Destroyed();
                
            }
        }
    }
}
