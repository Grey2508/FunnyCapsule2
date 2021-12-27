using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody?.GetComponent<CheckpointControl>()?.SetNewCheckpoint(transform.position);
    }
}
