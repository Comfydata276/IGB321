using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherController : MonoBehaviour
{
    public Transform playerTransform;
    public Transform tetherPoint;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        DeactivateTether();
    }

    private void Update()
    {
        lineRenderer.SetPosition(0, playerTransform.position);
        lineRenderer.SetPosition(1, tetherPoint.position);
    }

    public void ActivateTether()
    {
        lineRenderer.enabled = true;
    }

    public void DeactivateTether()
    {
        lineRenderer.enabled = false;
    }
}
