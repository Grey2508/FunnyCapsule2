using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody HenBody;

    private Transform _playerTransform;

    public float Speed = 3;
    public float TimeToReachSpeed = 1;

    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;

        Vector3 Force = HenBody.mass * (toPlayer * Speed - HenBody.velocity) / TimeToReachSpeed;

        HenBody.AddForce(Force);
    }
}
