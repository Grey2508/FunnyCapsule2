using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public Transform BodyTransform;
    public Transform PointerTransform;

    public UnityEvent WinEvents;

    private void OnTriggerEnter(Collider other)
    {
        PlayerHealth health = other.attachedRigidbody?.GetComponent<PlayerHealth>();
        
        if (health == null || health.Health <= 0)
            return;

        other.attachedRigidbody.velocity = Vector3.zero;

        BodyTransform.rotation = Quaternion.Euler(Vector3.zero);
        PointerTransform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));

        Cursor.visible = true;

        WinEvents.Invoke();
    }
}
