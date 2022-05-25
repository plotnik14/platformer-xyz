﻿using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onHealing;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;

        public void ApplyDamage(int damageValue)
        {
            _health -= damageValue;
            _onDamage?.Invoke();
            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }

        public void ApplyHealing(int healingValue)
        {
            _health += healingValue;
            _onHealing?.Invoke();
        }
    }
}