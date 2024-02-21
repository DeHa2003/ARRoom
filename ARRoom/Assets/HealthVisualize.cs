using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthVisualize : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textHealth;

    private HealthInteractor healthInteractor;
    private ScoreInteractor scoreInteractor;

    public void Initialize()
    {
        healthInteractor = Game.GetInteractor<HealthInteractor>();
        scoreInteractor = Game.GetInteractor<ScoreInteractor>();

        healthInteractor.OnPlayerLifeChange += UpdateHealth;
        textHealth.text = healthInteractor.MaxHealth.ToString();
    }

    public void UpdateHealth(int health)
    {
        textHealth.text = health.ToString();
    }
}
