using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationSizeRoom : MovePanel
{
    private RoomInteractor roomInteractor;

    public override void Initialize()
    {
        base.Initialize();
        roomInteractor = Game.GetInteractor<RoomInteractor>();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();
        roomInteractor.HideRoom(OnComplete: roomInteractor.DestroyCurrentRoom);
    }
}
