using Unity.GraphToolkit.Editor;
using UnityEngine;

public class NodeRootView : Node
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        context.AddOutputPort<Node>("Child").Build();
    }
}
