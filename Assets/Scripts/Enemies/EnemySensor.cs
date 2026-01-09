using System;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{

    public Blackboard Blackboard;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            Blackboard.Target = other.transform;
            Blackboard.IsPlayerVisible = true;
            Blackboard.LastKnownPlayerPosition = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Blackboard.Target = null;
            Blackboard.IsPlayerVisible = false;
        }
    }
}
