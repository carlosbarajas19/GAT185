using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollerCamera : MonoBehaviour
{
    public Transform target;
    public float distance = 5;
    public float pitch = 45;
    public float sensitivity = 1;

    float yaw = 0;

    // Update is called once per frame
    void Update()
    {
        Quaternion qpitch = Quaternion.AngleAxis(pitch, Vector3.right); // .right = (1, 0, 0)

        Vector3 offset = qpitch * Vector3.back * distance; // .back = (0, 0, -1)

        transform.position = target.position + offset;
    }
}
