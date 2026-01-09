using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private NodeRoot _root;
    private EnemySensor _sensor;
    private Blackboard _blackboard;

    [SerializeField] private float _chaseSpeed = 5f;
    [SerializeField] private float _patrolSpeed = 3f;
    [SerializeField] private Transform[] _patrolPoints;
    [SerializeField] private float _attackCooldownTime = 1f;
    [SerializeField] private int _attackDamage = 10;

private void Start()
{
        // Initialize blackboard 
        _blackboard = new Blackboard();
        
        // Get sensor component and link blackboard
        _sensor = GetComponentInChildren<EnemySensor>();
        _sensor.Blackboard = _blackboard;
        
        // Add node root and selector
        _root = new NodeRoot();
        NodeSelector selector = new NodeSelector();
        _root.Child = selector;

        NodeSequence a = new NodeSequence();
        selector.Children.Add(a);
        NodeLeaf aa = new IsPlayerVisible(_blackboard);
        NodeLeaf ab = new Chase(transform, _blackboard, _chaseSpeed, 1f);
        NodeDecorator ac = new CooldownDecorator(new Attack(transform, _blackboard, _attackDamage), _attackCooldownTime);
        a.Children.Add(aa);
        a.Children.Add(ab);
        a.Children.Add(ac);
        
        NodeLeaf b = new Patrol(transform, _patrolPoints, _patrolSpeed, 0.2f);
        selector.Children.Add(b);
    }

    private void Update()
    {
        _root.Execute();
    }
}