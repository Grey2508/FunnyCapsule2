using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : MonoBehaviour
{
    public Animator Animator;
    public Rigidbody PlayerRigidbody;
    public Transform playerBodyTransform;

    void Update()
    {
        float dot = Vector3.Dot(-playerBodyTransform.forward, PlayerRigidbody.velocity);

        float sign = Mathf.Sign(dot);

        float blendValue = sign * Mathf.Abs(PlayerRigidbody.velocity.x) / 5f;

        Animator.SetFloat("Blend", blendValue);
        Animator.speed = Mathf.Abs(blendValue);
    }
}
