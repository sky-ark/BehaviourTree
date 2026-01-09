using UnityEngine;

public class Chase : NodeLeaf
{
    private Transform _self;
    private EnemySensor _sensor;
    private float _speed;
    private float _stopDistance;
    
    public Chase(Transform self, EnemySensor sensor, float speed = 5f, float stopDistance = 1f)
    {
        _self = self;
        _sensor = sensor;
        _speed = speed;
        _stopDistance = stopDistance;
    }
    
    public override NodeState Execute()
    {
        // Move towards the player
        Vector3 direction = (_sensor.DetectedPlayer.position - _self.position);
        float distance = direction.magnitude;
        // Check if within stop distance
        if (distance <= _stopDistance)
            return NodeState.SUCCESS;
        
        Vector3 move = direction.normalized * (_speed * Time.deltaTime);
        _self.position += move;
        
        if (move != Vector3.zero)
            _self.forward = move.normalized;
        
        return NodeState.RUNNING;
    }
}