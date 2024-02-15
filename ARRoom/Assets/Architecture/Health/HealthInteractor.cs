using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void ChangeHealth(int healthValue);

namespace Lessons.Architecture
{
    public class HealthInteractor : Interactor
    {
        public int CurrentHealth { get; private set; }
        public int MaxHealth { get; private set; } = 5;

        public event ChangeHealth OnPlayerLifeChange;
        public event Action OnPlayerOutOfLives;

        public override void Initialize()
        {
            base.Initialize();
            CurrentHealth = MaxHealth;
            OnPlayerLifeChange?.Invoke(CurrentHealth);
        }

        public void RemoveHealth(object sender, int value = 1)
        {
            if(CurrentHealth <= 0)
            {
                Debug.Log("Ошибка, вы уже проиграли");
                return;
            }

            CurrentHealth -= value;
            OnPlayerLifeChange?.Invoke(CurrentHealth);

            if (CurrentHealth == 0)
            {
                OnPlayerOutOfLives?.Invoke();
                return;
            }

        }
    }
}
