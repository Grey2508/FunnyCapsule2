using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    public int DamageValue = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.tag != "Player")
            return;

        other.attachedRigidbody.velocity = Vector3.zero;
        other.attachedRigidbody.GetComponent<CheckpointControl>()?.ToCheckpoint();
        other.attachedRigidbody.GetComponent<PlayerHealth>()?.TakeDamage(DamageValue);
    }
}
