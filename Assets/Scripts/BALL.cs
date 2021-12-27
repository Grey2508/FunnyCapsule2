using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BALL : MonoBehaviour
{
    public AudioSource Roll;
    public PitchAndPlay Hit;

    public Rigidbody Rigidbody;

    private bool _playing = false;
    private bool _inCollision = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            return;

        Hit.Play();

        _inCollision = true;
    }

    private void Update()
    {
        if (!_inCollision)
            return;

        if (Rigidbody.velocity.magnitude > 0.01f && !_playing)
        {
            Roll.Play();
            _playing = true;
        }

        if (Rigidbody.velocity.magnitude < 0.01f && _playing)
        {
            Roll.Stop();
            _playing = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
            return;

        Roll.Stop();
        _playing = false;

        _inCollision = false;
    }
}
