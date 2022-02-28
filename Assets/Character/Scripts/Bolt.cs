using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform start;
    [SerializeField] Transform end;

    [SerializeField] int segments;
    [SerializeField] float radius;

    void Update()
    {
        Vector3[] positions = new Vector3[segments + 1];

        Vector3 direction = end.position - start.position;//< get direction vector from end to start >;
        float length = direction.magnitude/segments; //< get length of each segment>;

        positions[0] = start.position;//< set start position>;
        positions[segments] = end.position;//< set end position>;

        for (int i = 1; i < segments; i++)
        {
            positions[i] = start.position + direction.normalized * length * i;//< normalized direction* length * ???>;
            positions[i] = positions[i] + Random.insideUnitSphere * radius;//< Random inside unit sphere* radius>;
        }

        lineRenderer.positionCount = positions.Length;
        lineRenderer.SetPositions(positions);
    }
}

