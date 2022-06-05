using System.Collections.Generic;
using UnityEngine;

namespace Solids
{
    public class Solid
    {
        private const string ColliderResourcePath = "CircleCollider";
        private readonly Collider2D _collider;
        private readonly Vector3 _speed;
        
        public Solid()
        {
            _collider = CollidersFactory.Instance.CreateInstance(ColliderResourcePath);
            _speed = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
        }
        
        public void Move(float deltaTime)
        {
            _collider.transform.position += _speed * deltaTime;
        }

        public void ChangePosition(Vector3 position)
        {
            _collider.transform.position = position;
        }
        
        public bool Collide(List<Solid> solids)
        {
            foreach (var solid in solids)
            {
                if (solid == this) continue;
                if (_collider.IsTouching(solid._collider))
                {
                    return true;
                }
            }
            
            return false;
        }
        
        public void Destroy()
        {
            if (_collider) Object.Destroy(_collider.gameObject);
            Debug.Log("Solid Destroyed");
        }
        
        ~Solid() => Destroy();
    }
}