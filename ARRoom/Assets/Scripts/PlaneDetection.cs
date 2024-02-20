using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaneDetection : MonoBehaviour, IPointInPlaneDetection
{
    private Action OnSpawnPoint;

    [SerializeField] private VisibleLine visibleLine;
    [SerializeField] private ARRaycastManager raycastManager;
    [SerializeField] private GameObject marker; 
    [SerializeField] private Point pointPref;

    private Vector2 screenCenter = new(Screen.width / 2, Screen.height / 2);
    private bool isActive = false;

    public void AddActionOnSpawn(Action action)
    {
        OnSpawnPoint += action;
    }

    public void RemoveActionOnSpawn(Action action)
    {
        OnSpawnPoint -= action;
    }

    public void ActivateFindDefaultPoint()
    {
        //StartCoroutine(FindPoint());
        StartCoroutine(FindPoint_Coroutine());
    }

    public void ActivateFindMinMaxLengthFromPoint(Vector3 point, float maxLength, float minLength = 0)
    {
        visibleLine.ActivateLineRenderer(true);
        visibleLine.SetFirstPos(point);
        StartCoroutine(FindMinMaxLengthOfPoint_Coroutine(point, maxLength, minLength));
    }



    public void ActivateFind()
    {
        StartCoroutine(FindPoint());
        //StartCoroutine(FindPoint_Coroutine(description));
    }

    private IEnumerator FindPoint_Coroutine()
    {
        isActive = true;

        while (isActive)
        {
            List<ARRaycastHit> raycastHits = new();

            if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), raycastHits, TrackableType.Planes))
            {
                if (raycastHits.Count > 0)
                {
                    marker.SetActive(true);
                    marker.transform.position = raycastHits[0].pose.position;

                    if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                    {
                        isActive = false;
                        OnSpawnPoint?.Invoke();
                        Point point = Instantiate(pointPref, raycastHits[0].pose.position, pointPref.transform.rotation);
                        PlanePoints.AddPoint(point);
                    }
                }
            }
            else
            {
                marker.SetActive(false);
            }
            yield return null;
        }
    }

    IEnumerator FindPoint()
    {
        isActive = true;

        while (isActive)
        {
            Ray ray = Camera.main.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider != null)
                {
                    marker.SetActive(true);
                    marker.transform.position = hit.point;

                    if (Input.GetMouseButtonDown(0))
                    {
                        isActive = false;
                        OnSpawnPoint?.Invoke();
                        Point point = Instantiate(pointPref, hit.point, pointPref.transform.rotation);
                        PlanePoints.AddPoint(point);
                    }
                }
                else
                {
                    marker.SetActive(false);
                }
            }
            yield return null;
        }
    }

    IEnumerator FindMinMaxLengthOfPoint_Coroutine(Vector3 fromPoint, float maxLength, float minLength, string description = null)
    {
        isActive = true;

        while (isActive)
        {
            List<ARRaycastHit> raycastHits = new();

            if (raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), raycastHits, TrackableType.Planes))
            {
                if (raycastHits.Count > 0)
                {
                    float distance = Vector3.Distance(fromPoint, raycastHits[0].pose.position);
                    visibleLine.SetSecondPos(raycastHits[0].pose.position);

                    if (distance > maxLength || distance <= minLength)
                    {
                        marker.SetActive(false);
                    }
                    else
                    {
                        marker.SetActive(true);
                        marker.transform.position = raycastHits[0].pose.position;

                        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
                        {
                            isActive = false;
                            OnSpawnPoint?.Invoke();
                            Point point = Instantiate(pointPref, raycastHits[0].pose.position, pointPref.transform.rotation);
                            PlanePoints.AddPoint(point);
                        }
                    }
                }
            }
            else
            {
                marker.SetActive(false);
            }
            yield return null;
        }
    }

    //IEnumerator FindMinMaxLengthOfPoint_Coroutine(Vector3 fromPoint, float maxLength, float minLength, string description = null)
    //{
    //    isActive = true;

    //    while (isActive)
    //    {
    //        Ray ray = Camera.main.ScreenPointToRay(screenCenter);

    //        if (Physics.Raycast(ray, out RaycastHit hit))
    //        {
    //            float distance = Vector3.Distance(fromPoint, hit.point);

    //            if (hit.collider != null)
    //            {
    //                visibleLine.SetSecondPos(hit.point);
    //                if (distance > maxLength || distance <= minLength)
    //                {
    //                    marker.SetActive(false);
    //                }
    //                else
    //                {
    //                    marker.SetActive(true);
    //                    marker.transform.position = hit.point;

    //                    if (Input.GetMouseButtonDown(0))
    //                    {
    //                        isActive = false;
    //                        OnSpawnPoint?.Invoke();
    //                        Point point = Instantiate(pointPref, hit.point, pointPref.transform.rotation);
    //                        //points.Add(point);
    //                        PlanePoints.AddPoint(point);
    //                        visibleLine.ActivateLineRenderer(false);
    //                    }
    //                }
    //            }
    //        }
    //        yield return null;
    //    }
    //}

    //private void FindPoint()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(screenCenter);

    //    if (Physics.Raycast(ray, out RaycastHit hit))
    //    {
    //        if (hit.collider != null)
    //        {
    //            marker.SetActive(true);
    //            marker.transform.position = hit.point;

    //            if (Input.GetMouseButtonDown(0))
    //            {
    //                isActive = false;
    //                OnSpawnPoint?.Invoke();
    //                Point point = Instantiate(pointPref, hit.point, pointPref.transform.rotation);
    //                points.AddPoint(point);
    //            }
    //        }
    //        else
    //        {
    //            marker.SetActive(false);
    //        }
    //    }
    //}

    //private void FindPoint()
    //{
    //    Ray ray = Camera.main.ScreenPointToRay(screenCenter);

    //    if (Physics.Raycast(ray, out RaycastHit hit))
    //    {
    //        if (hit.collider != null)
    //        {
    //            marker.SetActive(true);
    //            marker.transform.position = hit.point;

    //            if (Input.GetMouseButtonDown(0))
    //            {
    //                isActive = false;
    //                OnSpawnPoint?.Invoke();
    //                Point point = Instantiate(pointPref, hit.point, pointPref.transform.rotation);
    //                points.AddPoint(point);
    //            }
    //        }
    //        else
    //        {
    //            marker.SetActive(false);
    //        }
    //    }
    //}

    //public void FindPoint()
    //{
    //    StartCoroutine(FindPoint_Coroutine2());
    //}

    ////private void FindPosition()
    ////{
    ////    if (Input.GetMouseButtonDown(0))
    ////    {
    ////        if (Physics.Raycast(Ray, out RaycastHit hit))
    ////        {
    ////            if (hit.collider != null)
    ////            {
    ////                OnChoosePosition?.Invoke();

    ////                points.AddPoint(hit.point);

    ////                GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    ////                obj.transform.position = hit.point;
    ////                obj.transform.localScale = new Vector3(8, 8, 8);
    ////                isActive = false;
    ////            }
    ////        }
    ////    }
    ////}

    private IEnumerator FindPoint_Coroutine2()
    {
        isActive = true;


        while (isActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider != null)
                    {
                        isActive = false;
                        OnSpawnPoint?.Invoke();
                        Point point = Instantiate(pointPref, hit.point, Quaternion.identity);
                        //points.Add(point);
                    }
                }
            }
            yield return null;
        }
    }

    ////private void ShowMarker()
    ////{
    ////    if (isActiveDetection)
    ////    {
    ////        List<ARRaycastHit> raycastHits = new();
    ////        raycastManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), raycastHits, TrackableType.Planes);

    ////        if (raycastHits.Count > 0)
    ////        {
    ////            OnFoundPlanes?.Invoke();
    ////            marker.SetActive(true);
    ////            marker.transform.position = raycastHits[0].pose.position;

    ////            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
    ////            {
    ////                isActiveDetection = false;
    ////                OnFoundZeroPositionToSpawn();
    ////            }
    ////        }
    ////    }
    ////}
}
