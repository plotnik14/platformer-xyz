using System.Collections;
using PixelCrew.Utils.ObjectPool;
using UnityEngine;

namespace PixelCrew.Creatures.Weapons
{
    public class BaseProjectile : MonoBehaviour
    {
        [SerializeField] protected float _speed;
        [SerializeField] protected float _ttl;
        [SerializeField] protected bool _invertX;

        protected Rigidbody2D Rigidbody;
        protected int Direction;
        protected Coroutine _currentSelfDestroy;
        
        protected virtual void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            SetDirection();
            UpdateTimer();
        }

        protected void SetDirection()
        {
            var mod = _invertX ? -1 : 1;
            Direction = transform.lossyScale.x * mod > 0 ? 1 : -1;     
        }
        
        public void Stop()
        {
            Rigidbody.velocity = Vector2.zero;
        }

        private IEnumerator SelfDestroyTimer()
        {
            yield return new WaitForSeconds(_ttl);

            var poolItem = GetComponent<PoolItem>();
            
            if (poolItem != null)
                poolItem.Release();
            else
                Destroy(this);

            _currentSelfDestroy = null;
        }

        protected void UpdateTimer()
        {
            if (_currentSelfDestroy != null)
                StopCoroutine(_currentSelfDestroy);
            
            if (_ttl > 0)
                StartCoroutine(SelfDestroyTimer());
        }
    }
}
