using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInputData : MonoBehaviour
{
    [SerializeField] private RoomController roomController;
    [SerializeField] private PlaneDetection planeDetection;
    [SerializeField] private NotificationControl notificationControl;

    private RoomInteractor roomInteractor;
    private PointInPlaneDetectionInteractor detectionInteractor;
    private NotificationInteractor notificationInteractor;

    public virtual void Initialize()
    {
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
        roomInteractor = Game.GetInteractor<RoomInteractor>();
        detectionInteractor = Game.GetInteractor<PointInPlaneDetectionInteractor>();

        notificationInteractor.SetData(notificationControl);
        roomInteractor.SetData(roomController);
        detectionInteractor.SetData(planeDetection);
    }
}
