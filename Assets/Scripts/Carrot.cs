using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot : MonoBehaviour
{
    public float Speed;
    public Rigidbody CarrotBody;

    void Start()
    {
        transform.rotation = Quaternion.identity;

        Transform playerTransform = GameObject.FindWithTag("Player").transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;

        CarrotBody.velocity = toPlayer * Speed;

        Destroy(gameObject, 3f);
    }
}
