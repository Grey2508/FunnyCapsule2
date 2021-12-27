using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBullets : MonoBehaviour
{
    public int GunIndex = 1;
    public int NumberOfBullets = 30;

    private void OnTriggerEnter(Collider other)
    {
        PlayerArmory player = other.attachedRigidbody?.GetComponent<PlayerArmory>();

        if (player)
        {
            player.AddBullets(GunIndex, NumberOfBullets);
            Destroy(gameObject);
        }
    }
}
