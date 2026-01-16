using Unity.GraphToolkit.Editor;
using UnityEngine;

public class SequenceNode : Node
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddInputPort<Node>("Parent").Build();
        context.AddOutputPort<Node>("Children").Build();
    }
}
