using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCameraRotate : MonoBehaviour
{
    public Vector3 TargetCameraRotate;
    public CameraRotate CameraRotate;
    public float NewRotationSpeed = 2;

    private Vector3 _oldCameraRotate;
    private float _oldRotationSpeed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody.tag != "Player")
            return;

        _oldRotationSpeed = CameraRotate.RotationSpeed;
        _oldCameraRotate = CameraRotate.GetCurrentEuler();

        CameraRotate.RotationSpeed = NewRotationSpeed;
        
        CameraRotate.SetTargetEuler(TargetCameraRotate);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.attachedRigidbody.tag != "Player")
            return;

        CameraRotate.RotationSpeed = _oldRotationSpeed;
        CameraRotate.SetTargetEuler(_oldCameraRotate);
    }
}
