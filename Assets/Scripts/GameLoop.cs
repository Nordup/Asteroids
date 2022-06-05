using System.Collections.Generic;
using System.Linq;
using Solids;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    public GameArea GameArea;
    public List<Solid> Solids;
    
    private bool _isRunning;
    
    private void Start()
    {
        GameArea = new GameArea();
    }
    
    public void Run()
    {
        Solids = GameArea.SpawnAsteroids();
        _isRunning = true;
    }
    
    private void FixedUpdate()
    {
        if (!_isRunning || Solids == null) return;
        foreach (var solid in Solids) solid.Move(Time.fixedDeltaTime);
        var collided = Solids.Where(solid => solid.Collide(Solids)).ToList();
        collided.ForEach(solid =>
        {
            Solids.Remove(solid);
            solid.Destroy();
        });
    }

    public void End()
    {
        _isRunning = false;
    }
}