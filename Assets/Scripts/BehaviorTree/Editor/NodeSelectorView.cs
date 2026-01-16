using Unity.GraphToolkit.Editor;
using UnityEngine;

public class NodeSelectorView : Node
{
    protected override void OnDefinePorts(IPortDefinitionContext context)
    {
        foreach (IPort outputPort in this.GetOutputPorts())
        {
            outputPort.firstConnectedPort.GetNode();
        }
        context.AddInputPort<Node>("Parent").Build();
        context.AddOutputPort<Node>("Children").Build();
    }
}
