using System;
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

        public void CreateCustomNotification(string hand, string description)
        {
            notification.CreateNotification(hand, description);
        }

        public void CreateCustomActionNotification(Action action, string description)
        {
            notification.CreateActionNotification(action, description);
        }

        public void CreateOnExitGameActionNotification()
        {
            notification.CreateActionNotification(Application.Quit, "Вы уверены что хотите выйти из игры?");
        }

        public void DestroyNotification()
        {
            notification.DestroyNotification();
        }

        public void DestroyActionNotification()
        {
            notification.DestroyActionNotification();
        }
    }
}

public interface INotification
{
    void CreateNotification(string hand, string description);
    void CreateActionNotification(Action action, string description);
    void DestroyNotification();
    void DestroyActionNotification();
}

