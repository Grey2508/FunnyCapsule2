using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject EffectPrefab;

    void Start()
    {
        Destroy(gameObject, 3);
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyBullet();
    }

    private void OnTriggerEnter(Collider other)
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Instantiate(EffectPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
