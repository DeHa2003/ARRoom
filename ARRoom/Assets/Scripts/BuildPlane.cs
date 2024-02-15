using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlane : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private float radius;
    [SerializeField] private GameObject room;

    private GameObject plane;
    private void Start()
    {
        CreatePlane();
    }

    public void CreatePlane()
    {
        plane = GameObject.CreatePrimitive(PrimitiveType.Plane);
    }

    private void Change()
    {
        Vector3 sideA = points[1].position - points[0].position;
        Vector3 sideB = points[2].position - points[0].position;

        Vector3 spawn = (points[2].position + points[1].position) / 2;

        float width = sideA.magnitude / 10;
        float length = sideB.magnitude / 10;

        Vector3 sizeCube = room.GetComponent<MeshRenderer>().bounds.size;

        float yoffset = sizeCube.y / 2;
        room.transform.position = spawn - (-plane.transform.up * yoffset);

        plane.transform.position = spawn;

        Vector3 vector;

        if(sideA.magnitude > sideB.magnitude)
        {
            vector = sideA;
            plane.transform.localScale = new Vector3(length, 1, width);
            room.transform.localScale = new Vector3(length*10, 2, width*10);
        }
        else
        {
            vector = sideB;
            plane.transform.localScale = new Vector3(width, 1, length);
            room.transform.localScale = new Vector3(width*10, 2, length*10);
        }
        Quaternion rotation = Quaternion.LookRotation(vector);
        plane.transform.rotation = rotation;
        room.transform.rotation = rotation;
    }

    private void Update()
    {
        if(plane == null) { return; }

        Change();
    }

    private void ChangeSizeMap()
    {
        //Vector3 sizePlane = plane.GetComponent<MeshRenderer>().bounds.size;
        //Vector3 sizeCube = room.GetComponent<MeshRenderer>().bounds.size;
        //if(sizePlane.z > sizePlane.x)
        //{
        //    room.transform.localScale = new Vector3(sizePlane.x, 2, sizePlane.z);
        //}
        //else
        //{
        //    room.transform.localScale = new Vector3(sizePlane.z, 2, sizePlane.x);
        //}
        //float yoffset = sizeCube.y/2;
        //room.transform.rotation = plane.transform.rotation;
        //room.transform.position = plane.transform.position - (-plane.transform.up * yoffset);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(points[0].position, radius);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(points[1].position, radius);
        Gizmos.DrawSphere(points[2].position, radius);
    }
}
