using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acorn : MonoBehaviour
{
    public Vector3 Velocity;
    public float MaxRotationSpeed = 10;
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddRelativeForce(Velocity, ForceMode.VelocityChange);
        
        float x = Random.Range(-MaxRotationSpeed, MaxRotationSpeed);
        float y = Random.Range(-MaxRotationSpeed, MaxRotationSpeed);
        float z = Random.Range(-MaxRotationSpeed, MaxRotationSpeed);
        
        rigidbody.angularVelocity = new Vector3(x, y, z);

        Destroy(gameObject, 4);
    }
}
