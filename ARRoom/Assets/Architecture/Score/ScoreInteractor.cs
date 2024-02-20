using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnChangedScore(int health);

namespace Lessons.Architecture
{
    public class ScoreInteractor : Interactor
    {
        public OnChangedScore OnChangedScore;
        public OnChangedScore OnChangedMaxScore;

        public int Score { get; private set; }
        public int MaxScore { get; private set; }
        public float KPD { get; private set; }

        private ScoreRepository scoreRepository;
        public override void Initialize()
        {
            base.Initialize();
            scoreRepository = Game.GetRepository<ScoreRepository>();
        }

        public void RestoreScore()
        {
            Score = 0;
            OnChangedScore?.Invoke(Score);
        }

        public override void OnStart()
        {
            base.OnStart();

            MaxScore = scoreRepository.maxscore;
            Score = 0;
        }

        public void AddScore(object sender, int value)
        {
            Score += value;
            OnChangedScore?.Invoke(Score);
            if(Score > MaxScore)
            {
                MaxScore = Score;
                OnChangedMaxScore?.Invoke(Score);
                scoreRepository.maxscore = MaxScore;
                scoreRepository.Save();
            }
        }
    }
}
