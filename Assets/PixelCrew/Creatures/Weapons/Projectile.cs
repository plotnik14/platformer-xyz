﻿using UnityEngine;

namespace PixelCrew.Creatures.Weapons
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Rigidbody2D _rigidbody;
        private int _direction;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            _direction = transform.lossyScale.x > 0 ? 1 : -1;
            var force = new Vector2(_direction * _speed, 0);
            _rigidbody.AddForce(force, ForceMode2D.Impulse);
        }
    }
}
