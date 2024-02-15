using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private TextMeshPro text;
    private Camera m_cam;
    private void Awake()
    {
        m_cam = Camera.main;
    }
}
