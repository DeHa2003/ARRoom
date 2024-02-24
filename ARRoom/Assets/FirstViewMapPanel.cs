using Lessons.Architecture;
using UnityEngine;

public class FirstViewMapPanel : MovePanel
{
    [SerializeField] private TimerVisualize timerVisualize;
    private RoomInteractor roomInteractor;
    public override void Initialize()
    {
        base.Initialize();

        roomInteractor = Game.GetInteractor<RoomInteractor>();
        timerVisualize.Initialize();
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
        roomInteractor.BuildRoom(1);
        timerVisualize.StartTimer(30);
    }

    public override void ClosePanel()
    {
        roomInteractor.HideRoom();
        timerVisualize.StopTimer();
        base.ClosePanel();
    }

    public void Exit()
    {
        roomInteractor.HideRoom(OnComplete: roomInteractor.DestroyCurrentRoom);
    }
}
