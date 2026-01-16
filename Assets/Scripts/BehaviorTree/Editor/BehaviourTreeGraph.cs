using System;
using Unity.GraphToolkit.Editor;
using UnityEditor;

[Graph(AssetExtension)]
[Serializable]
public class BehaviourTreeGraph : Graph
{
    public const string AssetExtension = "btgraph";

    [MenuItem("Assets/Create/Graph Toolkit Samples/Behaviour Tree Graph", false)]
    public static void CreateAssetFile()
    {
        GraphDatabase.PromptInProjectBrowserToCreateNewAsset<BehaviourTreeGraph>();
    }
}
