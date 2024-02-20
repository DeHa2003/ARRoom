using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TimerVisualize : MonoBehaviour
{
    public UnityEvent OnStartTimerEvent;
    public UnityEvent OnFinishTimerEvent;

    [SerializeField] private TextMeshProUGUI textToVisibleTimer;

    private TimerInteractor timerInteractor;

    public void Initialize()
    {
        timerInteractor = Game.GetInteractor<TimerInteractor>();
    }

    public void StartTimer(float time)
    {
        timerInteractor.OnStartTimer += OnStartTimer;
        timerInteractor.OnIterationTimer += OnIterationTimer;
        timerInteractor.OnFinishTimer += OnFinishTimer;

        timerInteractor.PlayTimer(time);
    }

    public void StopTimer()
    {
        timerInteractor.OnStartTimer -= OnStartTimer;
        timerInteractor.OnIterationTimer -= OnIterationTimer;
        timerInteractor.OnFinishTimer -= OnFinishTimer;

        timerInteractor.StopTimer();
    }

    private void OnStartTimer()
    {
        OnStartTimerEvent?.Invoke();
    }

    private void OnFinishTimer()
    {
        OnFinishTimerEvent?.Invoke();
    }

    private void OnIterationTimer()
    {
        textToVisibleTimer.text = timerInteractor.TextTime;
    }
}
