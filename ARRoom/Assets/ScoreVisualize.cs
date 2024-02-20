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
        scoreInteractor.OnChangedScore += UpdateScore;
        textScore.text = scoreInteractor.Score.ToString();
    }

    public void UpdateScore(int health)
    {
        textScore.text = health.ToString();
    }
}
