using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float Speed = 5;
    public float RotationSpeed = 2;

    public EnemyHealth SelfHealth;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;

        Invoke("Die", 7);
    }

    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * Speed;

        Vector3 toPlayer = _playerTransform.position - transform.position;

        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
    }

    void Die()
    {
        SelfHealth.TakeDamage(100);
    }
}
