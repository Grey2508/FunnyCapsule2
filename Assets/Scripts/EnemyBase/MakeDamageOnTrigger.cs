using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamageOnTrigger : MonoBehaviour
{
    public int DamageValue = 1;

    ////нанесение урона при вхождении
    //private void OnTriggerEnter(Collider other)
    //{
    //    other.attachedRigidbody?.GetComponent<PlayerHealth>()?.TakeDamage(DamageValue);

    //}

    //чтобы не было соблазна сидеть внутри врага
    private void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody?.GetComponent<PlayerHealth>()?.TakeDamage(DamageValue);
    }
}
