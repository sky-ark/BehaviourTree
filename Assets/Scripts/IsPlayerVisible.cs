using DefaultNamespace;
using UnityEngine;

public class IsPlayerVisible : NodeLeaf
{
    private EnemySensor _sensor;
    
    public IsPlayerVisible(EnemySensor sensor)
    {
        _sensor = sensor;
    }

    public override NodeState Execute()
    {
        return _sensor.IsVisible ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
