using Unity.GraphToolkit.Editor;
using UnityEngine;

public class IsPlayerVisibleNode : Node
{
    public string RealNode = "IsPlayerVisible";
    
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort<Node>("Parent").Build();
    }

    public bool PlayerVisible = false;
    
    public NodeState Execute()
    {
        return PlayerVisible ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
