using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsRaycast : MonoBehaviour
{
    //public event Action OnChoosePosition;

    [SerializeField] private Camera cam;
    private Ray Ray => cam.ScreenPointToRay(Input.mousePosition);
    private bool isActive = false;

    private void Update()
    {
        //if (isActive)
        //{
        //    FindPosition();
        //}
    }

    //private void FindPosition()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        if (Physics.Raycast(Ray, out RaycastHit hit))
    //        {
    //            if(hit.collider != null)
    //            {
    //                OnChoosePosition?.Invoke();

    //                points.AddPoint(hit.point);

    //                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //                obj.transform.position = hit.point;
    //                obj.transform.localScale = new Vector3(8, 8, 8);
    //                isActive = false;
    //            }
    //        }
    //    }
    //}

    public void ActivateFindPosition(object sender, bool isActivate)
    {
        isActive = isActivate;
    }
}
