using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleLine : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    public void SetFirstPos(Vector3 first)
    {
        lineRenderer.SetPosition(0, first);
    }

    public void SetSecondPos(Vector3 second)
    {
        lineRenderer.SetPosition(1, second);
    }

    public void ActivateLineRenderer(bool activate)
    {
        lineRenderer.enabled = activate;    
    }
}
