using System.Collections.Generic;
using Solids;
using UnityEngine;

public class GameArea
{
    private const string ColliderResourcePath = "GameArea";
    private readonly Collider2D _areaCollider;
    
    public GameArea()
    {
        _areaCollider = CollidersFactory.Instance.CreateInstance(ColliderResourcePath);
    }
    
    public List<Solid> SpawnAsteroids()
    {
        var solids = new List<Solid>();
        solids.Add(new Solid());
        solids.Add(new Solid());
        return solids;
    }
}