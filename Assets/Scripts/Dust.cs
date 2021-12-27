using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    public ParticleSystem DustPS;

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];

        ParticleSystem newDust = Instantiate(DustPS, contact.point, Quaternion.Euler(contact.normal));

        var main = newDust.main;
        main.startSpeed = Mathf.Clamp(collision.impulse.magnitude * 0.1f, 1.5f, 3);

        newDust.Play();
    }
}
