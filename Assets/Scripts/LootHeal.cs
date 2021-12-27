using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int HealthValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth player = other.attachedRigidbody?.GetComponent<PlayerHealth>();

        if (player)
        {
            player.AddHealth(HealthValue);
            Destroy(gameObject);
        }
    }
}
