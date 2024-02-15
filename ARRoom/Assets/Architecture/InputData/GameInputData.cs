using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputData : MonoBehaviour
{
    [SerializeField] private RoomController roomController;
    [SerializeField] private PlaneDetection planeDetection;

    private RoomInteractor roomInteractor;
    private PointInPlaneDetectionInteractor detectionInteractor;

    public virtual void Initialize()
    {
        roomInteractor = Game.GetInteractor<RoomInteractor>();
        detectionInteractor = Game.GetInteractor<PointInPlaneDetectionInteractor>();

        roomInteractor.SetData(roomController);
        detectionInteractor.SetData(planeDetection);
    }
}
