﻿using PixelCrew.Components;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Creatures
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField] private LayerCheck _vision;
        [SerializeField] private LayerCheck _canAttack;

        [SerializeField] private float _alarmDelay;
        [SerializeField] private float _attackCooldown;
        [SerializeField] private float _missHeroCooldown;

        private Coroutine _current;
        private GameObject _target;
        private bool _isDead;

        private SpawnListComponent _particles;
        private Creature _creature;
        private Animator _animator;
        private Patrol _patrol;

        protected static readonly int IsDeadKey = Animator.StringToHash("is-dead");

        private void Awake()
        {
            _particles = GetComponent<SpawnListComponent>();
            _creature = GetComponent<Creature>();
            _animator = GetComponent<Animator>();
            _patrol = GetComponent<Patrol>();
        }

        private void Start()
        {
            StartState(_patrol.DoPatrol());
        }

        public void OnHeroInVision(GameObject go)
        {
            if (_isDead) return;

            _target = go;

            StartState(AgroToHero());
        }

        private IEnumerator GoToHero()
        {
            while (_vision.IsTouchingLayer)
            {
                if (_canAttack.IsTouchingLayer)
                {
                    StartState(Attack());
                }
                else
                {
                    SetDirectionToTarget();

                }

                yield return null;
            }

            _particles.Spawn("MissHero");
            yield return new WaitForSeconds(_missHeroCooldown);
        }

        private IEnumerator Attack()
        {
            while (_canAttack.IsTouchingLayer)
            {
                _creature.Attack();
                yield return new WaitForSeconds(_attackCooldown);
            }

            StartState(GoToHero());
        }

        private void SetDirectionToTarget()
        {
            var direction = _target.transform.position - transform.position;
            direction.y = 0;
            _creature.SetDirection(direction.normalized);
        }

        private IEnumerator AgroToHero()
        {
            _particles.Spawn("Exclamation");

            yield return new WaitForSeconds(_alarmDelay);

            StartState(GoToHero());
        }

        private void StartState(IEnumerator coroutine)
        {
            _creature.SetDirection(Vector2.zero);

            if (_current != null)
            {
                StopCoroutine(_current);
            }

            _current = StartCoroutine(coroutine);
        }

        public void OnDie()
        {
            if (_isDead) return;

            _isDead = true;
            _animator.SetBool(IsDeadKey, true);

            _creature.OnDie();
            
            if (_current != null)
            {
                StopCoroutine(_current);
            }
        }

    }
}
