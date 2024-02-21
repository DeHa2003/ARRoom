using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreVisualize : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScore;

    private ScoreInteractor scoreInteractor;

    public void Initialize()
    {
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();
        scoreInteractor.OnChangedHitScore += UpdateScore;
        textScore.text = scoreInteractor.HitScore.ToString();
    }

    public void UpdateScore(int score)
    {
        textScore.text = score.ToString();
    }
}
