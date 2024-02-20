using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class TimerInteractor : Interactor
    {
        public string TextTime { get; private set; }

        public event Action OnStartTimer;
        public event Action OnFinishTimer;
        public event Action OnIterationTimer;

        private float time;

        public void PlayTimer(float startTime, float endTime = 0)
        {
            //Coroutines.StartRoutine(TimerCoroutine(startTime, endTime));
            Coroutines.Start_Coroutine(TimerCoroutine(startTime, endTime));
        }

        public void StopTimer()
        {
            Coroutines.Destroy_Coroutine();
        }

        private IEnumerator TimerCoroutine(float startTime, float endTime)
        {
            time = startTime;

            OnStartTimer?.Invoke();

            while (time > endTime)
            {
                time -= Time.deltaTime;
                int minutes = Mathf.FloorToInt(time / 60);
                int seconds = Mathf.FloorToInt(time % 60);

                TextTime = string.Format("{0:00}:{1:00}", minutes, seconds);

                OnIterationTimer?.Invoke();
                yield return null;
            }
            OnFinishTimer?.Invoke();
        }
    }
}
