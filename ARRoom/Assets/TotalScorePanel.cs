using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TotalScorePanel : Panel
{
    [SerializeField] private TextMeshProUGUI textKPD;
    [SerializeField] private TextMeshProUGUI textScore;
    [SerializeField] private TextMeshProUGUI textTotalScore;

    private ScoreInteractor scoreInteractor;
    private HealthInteractor healthInteractor;
    public override void Initialize()
    {
        base.Initialize();

        scoreInteractor = Game.GetInteractor<ScoreInteractor>();
        healthInteractor = Game.GetInteractor<HealthInteractor>();

        scoreInteractor.OnChangedKPD += VisualizeKPD;
        scoreInteractor.OnChangedHitScore += VisualizeHitScore;
        scoreInteractor.OnChangedTotalScore += VisualizeTotalScore;
    }

    public override void OpenPanel()
    {
        base.OpenPanel();
    }

    public override void ClosePanel()
    {
        base.ClosePanel();

        scoreInteractor.RestoreScore();
        healthInteractor.RestoreHealth();
    }

    private void OnDestroy()
    {
        scoreInteractor.OnChangedKPD -= VisualizeKPD;
        scoreInteractor.OnChangedHitScore -= VisualizeHitScore;
        scoreInteractor.OnChangedTotalScore -= VisualizeTotalScore;
    }


    private void VisualizeKPD(float kpd)
    {
        textKPD.text = kpd.ToString();
    }

    private void VisualizeHitScore(int score)
    {
        textScore.text = score.ToString();
    }

    private void VisualizeTotalScore(float score)
    {
        textTotalScore.text = score.ToString();
    }
}
