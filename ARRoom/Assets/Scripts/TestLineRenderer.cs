using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLineRenderer : MonoBehaviour
{
    [SerializeField] private Transform one;
    [SerializeField] private Transform two;
    [SerializeField] private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer.SetPosition(0, one.position);
        lineRenderer.SetPosition(1, two.position);
    }
}
