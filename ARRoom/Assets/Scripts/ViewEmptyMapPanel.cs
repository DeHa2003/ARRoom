using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ViewEmptyMapPanel : MovePanel
{
    private RoomInteractor roomInteractor;

    public override void Initialize()
    {
        base.Initialize();

        roomInteractor = Game.GetInteractor<RoomInteractor>();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        roomInteractor.BuildRoom(0);
    }
}
