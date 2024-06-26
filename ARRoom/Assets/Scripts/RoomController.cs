using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour, IRoomController
{
    public Room CurrentRoom { get; private set; }

    private List<Room> currentRooms = new();

    public Action OnShowRoom;
    public Action OnHideRoom;


    [SerializeField] private RoomObject[] roomPrefab;

    private List<Point> pointsToSpawn => PlanePoints.Points;

    public void BuildRoom(int index, float height, float offsetSize)
    {
        CurrentRoom = Instantiate(roomPrefab[index].Room);

        Vector3 sideA = pointsToSpawn[1].transform.position - pointsToSpawn[0].transform.position;
        Vector3 sideB = pointsToSpawn[2].transform.position - pointsToSpawn[0].transform.position;

        float width = sideA.magnitude / offsetSize;
        float length = sideB.magnitude / offsetSize;

        if (sideA.magnitude > sideB.magnitude)
        {
            CurrentRoom.transform.localScale = new Vector3(length, height, width);
            CurrentRoom.transform.rotation = Quaternion.LookRotation(sideA);
        }
        else
        {
            CurrentRoom.transform.localScale = new Vector3(width, height, length);
            CurrentRoom.transform.rotation = Quaternion.LookRotation(sideB);
        }
        Vector3 spawn = (pointsToSpawn[2].transform.position + pointsToSpawn[1].transform.position) / 2;
        CurrentRoom.transform.position = spawn + new Vector3(0, CurrentRoom.transform.localScale.y / 2, 0);
        CurrentRoom.Initialize();

        currentRooms.Add(CurrentRoom);
    }

    public void DestroyCurrentRoom()
    {
        if (currentRooms.Count == 0)
        {
            return;
        }

        currentRooms[0].Destroy();
    }

    public void SpawnObjects()
    {
        if(CurrentRoom == null)
        {
            return;
        }

        CurrentRoom.Spawn();
    }

    public void HideRoom(float time, Action OnComplete)
    {
        if (CurrentRoom == null) { return; }

        CurrentRoom.transform.DOScale(Vector3.zero, time).OnComplete(() =>
        {
            OnComplete?.Invoke();
        });
    }

    public void ShowRoom(float time, Action OnComplete)
    {
        if (CurrentRoom == null) { return; }

        CurrentRoom.transform.DOScale(CurrentRoom.RoomScale, time).OnComplete(() =>
        {
            OnComplete?.Invoke();
        });
    }
}
