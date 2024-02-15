using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class PointInPlaneDetectionInteractor : Interactor
    {
        public IPointInPlaneDetection PointInPlaneDetection {  get; private set; }

        public void SetData(IPointInPlaneDetection pointInPlaneDetection)
        {
            this.PointInPlaneDetection = pointInPlaneDetection;
        }

        public void AddActionOnSpawn(Action action)
        {
            PointInPlaneDetection.AddActionOnSpawn(action);
        }

        public void RemoveActionOnSpawn(Action action)
        {
            PointInPlaneDetection.RemoveActionOnSpawn(action);
        }

        public void ActivateFindDefaultPoint()
        {
            PointInPlaneDetection.ActivateFindDefaultPoint();
        }

        public void ActivateFindMinMaxLengthFromPoint(Vector3 point, float maxLength, float minLength = 0)
        {
            PointInPlaneDetection.ActivateFindMinMaxLengthFromPoint(point, maxLength, minLength);
        }
    }
}

public interface IPointInPlaneDetection
{
    public void AddActionOnSpawn(Action action);
    public void RemoveActionOnSpawn(Action action);
    public void ActivateFindDefaultPoint();
    public void ActivateFindMinMaxLengthFromPoint(Vector3 point, float maxLength, float minLength);
}
