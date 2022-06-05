using UnityEngine;

namespace Solids
{
    public class CollidersFactory : SingletonTemplate<CollidersFactory>
    {
        public Collider2D CreateInstance(string resourcePath)
        {
            var colliderPrefab = Resources.Load<Collider2D>(resourcePath);
            if (colliderPrefab) return Instantiate(colliderPrefab, transform);
            
            Debug.LogError($"Resource at {resourcePath} not found");
            return null;
        }
    }
}