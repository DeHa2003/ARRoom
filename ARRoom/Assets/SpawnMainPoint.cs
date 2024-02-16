using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnMainPoint : MonoBehaviour
{
    public UnityEvent OnPointSpawn;
    private PointInPlaneDetectionInteractor detectionInteractor;
    private NotificationInteractor notificationInteractor;

    public void Initialize()
    {
        detectionInteractor = Game.GetInteractor<PointInPlaneDetectionInteractor>();
        notificationInteractor = Game.GetInteractor<NotificationInteractor>();
    }

    public void ActivateSpawn()
    {
        detectionInteractor.AddActionOnSpawn(FindPosition);
        detectionInteractor.ActivateFindDefaultPoint();
    }

    public void DiactivateSpawn()
    {
        detectionInteractor.RemoveActionOnSpawn(FindPosition);
    }

    private void FindPosition()
    {
        notificationInteractor.CreateNotification("hrtjertrtreer", "Вы заспавнили первую точку");
        OnPointSpawn?.Invoke();
    }
}
