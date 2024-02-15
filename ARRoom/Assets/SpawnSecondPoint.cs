using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnSecondPoint : MonoBehaviour
{
    public UnityEvent OnPointSpawn;
    private PointInPlaneDetectionInteractor detectionInteractor;

    public void Initialize()
    {
        detectionInteractor = Game.GetInteractor<PointInPlaneDetectionInteractor>();
    }

    public void ActivateSpawn()
    {
        detectionInteractor.AddActionOnSpawn(FindPosition);
        detectionInteractor.ActivateFindMinMaxLengthFromPoint(PlanePoints.Points[0].transform.position, 9, 6);
    }

    public void DiactivateSpawn()
    {
        detectionInteractor.RemoveActionOnSpawn(FindPosition);
    }

    private void FindPosition()
    {
        OnPointSpawn?.Invoke();
    }
}
