using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Rigidbody HookRigidbody;

    public Collider Collider;
    public Collider PlayerCollider;
    public RopeGun RopeGun;

    private FixedJoint _fixedJoint;
    private bool _failCling = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (_failCling)
            return;

        HookRigidbody.useGravity = true;
        
        if (collision.gameObject.GetComponent<Unattached>() != null)
        {
            _failCling = true;
            return;
        }

        if (_fixedJoint == null)
        {
            _fixedJoint = gameObject.AddComponent<FixedJoint>();

            if (collision.rigidbody)
                _fixedJoint.connectedBody = collision.rigidbody;

            RopeGun.CreateSpring();
        }
    }

    public void StopFix()
    {
        if (_fixedJoint)
            Destroy(_fixedJoint);

        HookRigidbody.useGravity = false;
        _failCling = false;
    }

    private void Start()
    {
        Physics.IgnoreCollision(Collider, PlayerCollider);
    }
}
