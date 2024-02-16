using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class NotificationInteractor : Interactor
    {
        private INotification notification;

        public void SetData(INotification notification)
        {
            this.notification = notification;
        }

        public void CreateNotification(string hand, string description)
        {
            notification.CreateNotification(hand, description);
        }

        public void DestroyNotification()
        {
            notification.DestroyNotification();
        }
    }
}

public interface INotification
{
    void CreateNotification(string hand, string description);
    void DestroyNotification();
}

