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
        /*Vector3[] positions = new Vector3[???];

        Vector3 direction = < get direction vector from end to start >;
        float length = < get length of each segment>;

        positions[0] = < set start position>;
        positions[segments] = < set end position>;

        for (int i = 1; i < segments; i++)
        {
            positions[i] = start.position + < normalized direction* length * ???>;
            positions[i] = positions[i] + < Random inside unit sphere* radius>;
        }*/

        //lineRenderer.positionCount = positions.Length;
        //lineRenderer.SetPositions(positions);
    }
}

