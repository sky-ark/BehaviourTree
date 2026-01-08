using UnityEngine;

public class NodeCondition :NodeDecorator
{
    private bool _condition;
    public NodeCondition(NodeBase child, bool condition) : base(child)
    {
        _condition = condition;
    }
    public override NodeState Execute()
    {
        if (!_condition)
        {
            return NodeState.FAILURE;
        }
        return Child.Execute();
    }
}
