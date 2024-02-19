using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnMainPoint : MonoBehaviour
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
        detectionInteractor.ActivateFindDefaultPoint();
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
