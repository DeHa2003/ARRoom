using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnChangedHitScore(int hitScore);
public delegate void OnChangedTotalScore(float hitScore);
public delegate void OnChangedKPD(float kpd);

namespace Lessons.Architecture
{
    public class ScoreInteractor : Interactor
    {
        public OnChangedHitScore OnChangedHitScore;
        public OnChangedTotalScore OnChangedTotalScore;
        public OnChangedKPD OnChangedKPD;

        public int HitScore { get; private set; }
        public float TotalScore { get; private set; }
        public float KPD { get; private set; }


        public int HitScore_Record { get; private set; }
        public float TotalScore_Record { get; private set; }


        public int SuccessHitsCount;
        public int LoseHitsCount;

        private ScoreRepository scoreRepository;
        public override void Initialize()
        {
            base.Initialize();
            scoreRepository = Game.GetRepository<ScoreRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();

            HitScore_Record = scoreRepository.HitScore_Record;
            TotalScore_Record = scoreRepository.TotalScore_Record;

            RestoreScore();
        }

        public void AddSuccessHitCount()
        {
            SuccessHitsCount += 1;
            CalculateKPD();
            CalculateTotalScore();
        }

        public void AddLoseHitCount()
        {
            LoseHitsCount += 1;
            CalculateKPD();
            CalculateTotalScore();
        }

        public void RestoreScore()
        {
            HitScore = 0;
            SuccessHitsCount = 0;
            LoseHitsCount = 0;
            OnChangedHitScore?.Invoke(HitScore);
        }

        public void AddScore(int value)
        {
            HitScore += value;
            OnChangedHitScore?.Invoke(HitScore);
        }

        public void CalculateKPD()
        {
            KPD = (float)Math.Round(SuccessHitsCount * 1f / (SuccessHitsCount + LoseHitsCount) * 100, 2);
            OnChangedKPD?.Invoke(KPD);
        }

        public void CalculateTotalScore()
        {
            if(SuccessHitsCount == 0)
            {
                TotalScore = HitScore * 1f;
                OnChangedTotalScore?.Invoke(TotalScore);
                return;
            }

            if (LoseHitsCount == 0)
            {
                TotalScore = HitScore * 1f * SuccessHitsCount;
                OnChangedTotalScore?.Invoke(TotalScore);
                return;
            }

            TotalScore = (float)Math.Round(HitScore * 1f * (SuccessHitsCount * 1f / LoseHitsCount), 2);
            OnChangedTotalScore?.Invoke(TotalScore);
        }
    }
}
