using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class RoomInteractor : Interactor
    {
        private IRoomController roomController;

        public void SetData(IRoomController roomController)
        {
            this.roomController = roomController;
        }

        public void BuildRoom(int index, float height = 2, float offsetSize = 1)
        {
            roomController.BuildRoom(index, height, offsetSize);
        }

        public void SpawnObjects()
        {
            roomController.SpawnObjects();
        }

        public void ShowRoom(float time = 1, Action OnComplete = null)
        {
            roomController.ShowRoom(time, OnComplete);
        }

        public void HideRoom(float time = 1, Action OnComplete = null)
        {
            roomController.HideRoom(time, OnComplete);
        }

        public void DestroyCurrentRoom()
        {
            roomController.DestroyCurrentRoom();
        }
    }
}

public interface IRoomController
{
    public void BuildRoom(int index, float height, float offsetSize);
    public void DestroyCurrentRoom();
    public void SpawnObjects();
    public void HideRoom(float time, Action OnComplete);
    public void ShowRoom(float time, Action OnComplete);
}
