using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocitySetToZero : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
            return;

        collision.rigidbody.velocity = Vector3.zero;
    }
}
