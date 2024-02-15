using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnThirdPoint : MonoBehaviour
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
        detectionInteractor.ActivateFindMinMaxLengthFromPoint
            (PlanePoints.Points[0].transform.position,
            (PlanePoints.Points[1].transform.position - PlanePoints.Points[0].transform.position).magnitude * 0.8f,
            (PlanePoints.Points[1].transform.position - PlanePoints.Points[0].transform.position).magnitude * 0.5f);
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
