using System;
using DefaultNamespace;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private NodeRoot _root;

    [SerializeField] private float _chaseSpeed = 5f;
    [SerializeField] private float _patrolSpeed = 3f;
    [SerializeField] private Transform[] _patrolPoints;
    private void Start()
    {
        EnemySensor sensor = GetComponentInChildren<EnemySensor>();
        
        // Add node root and selector
        _root = new NodeRoot();
        NodeSelector selector = new NodeSelector();
        _root.Child = selector;

        NodeSequence a = new NodeSequence();
        selector.Children.Add(a);
        NodeLeaf aa = new IsPlayerVisible(sensor);
        NodeLeaf ab = new Chase(transform, sensor, _chaseSpeed, 1f);
        a.Children.Add(aa);
        a.Children.Add(ab);
        
        NodeLeaf b = new Patrol(transform, _patrolPoints, _patrolSpeed, 0.2f);
        selector.Children.Add(b);
    }

    private void Update()
    {
        _root.Execute();
    }
}
