using UnityEngine;

public class Chase : NodeLeaf
{
    private Transform _self;
    private Blackboard _blackboard;
    private float _speed;
    private float _attackRange;
    
    public Chase(Transform self, Blackboard blackboard, float speed = 5f, float attackRange = 1f)
    {
        _self = self;
        _blackboard = blackboard;
        _speed = speed;
        _attackRange = attackRange;
    }
    
    public override NodeState Execute()
    {
        // Move towards the player
        Vector3 direction = (_blackboard.Target.position - _self.position);
        float distance = direction.magnitude;
        // Check if within stop distance
        if (distance <= _attackRange)
            return NodeState.SUCCESS;
        
        Vector3 move = direction.normalized * (_speed * Time.deltaTime);
        _self.position += move;
        
        if (move != Vector3.zero)
            _self.forward = move.normalized;
        
        return NodeState.RUNNING;
    }
}