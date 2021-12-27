using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMakeDamage : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        MakeDamageOnCollision makeDamage = collision.gameObject.GetComponent<MakeDamageOnCollision>();

        if (makeDamage)
            Destroy(makeDamage);
    }
}
