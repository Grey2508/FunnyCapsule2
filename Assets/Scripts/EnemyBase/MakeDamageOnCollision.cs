using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    public int DamageValue = 1;

    //для врезавшихся врагов
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(DamageValue);
    }

    //для прилипших врагов
    private void OnCollisionStay(Collision collision)
    {
        collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(DamageValue);
    }
}
