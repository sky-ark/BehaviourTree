using System;
using UnityEngine;

public class EnemySensor : MonoBehaviour
{
    public bool IsVisible { get; private set; }
    public Transform DetectedPlayer { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player detected!");
            IsVisible = true;
            DetectedPlayer = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsVisible = false;
            DetectedPlayer = null;
        }
    }
}
