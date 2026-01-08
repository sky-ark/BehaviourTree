using DefaultNamespace;
using UnityEngine;

public class Patrol : NodeLeaf
{
    private Transform _self;
    private Transform[] _waypoints;
    private float _speed;
    private float _stopDistance;
    private int _currentIndex;
    
    public Patrol(Transform self, Transform[] waypoints, float speed = 3f, float stopDistance = 0.2f)
    {
        _self = self;
        _waypoints = waypoints;
        _speed = speed;
        _stopDistance = stopDistance;
        _currentIndex = 0;
    }
    
    public override NodeState Execute()
    {
        if (_waypoints == null || _waypoints.Length == 0)
            return NodeState.FAILURE;
        
        Vector3 direction = (_waypoints[_currentIndex].position - _self.position).normalized ;
        _self.position += direction * (_speed * Time.deltaTime);
        
        if (direction != Vector3.zero)
            _self.forward = direction;
        
        // Check if reached the waypoint
        if (Vector3.Distance(_self.position, _waypoints[_currentIndex].position) <= _stopDistance)
        {
            _currentIndex++;
            if(_currentIndex >= _waypoints.Length)
                _currentIndex = 0;
        }
        return NodeState.RUNNING;
    }
}
