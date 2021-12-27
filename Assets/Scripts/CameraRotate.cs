using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Transform CameraTransform;
    public float RotationSpeed = 5;
    public Vector3 DefaultEuler;

    private Vector3 _targetEuler;
    private void Start()
    {
        _targetEuler = CameraTransform.localRotation.eulerAngles;
    }
    void Update()
    {
        CameraTransform.localRotation = Quaternion.Lerp(CameraTransform.localRotation, Quaternion.Euler(_targetEuler), Time.deltaTime * RotationSpeed);
    }

    public void SetTargetEuler(Vector3 newTargetEuler)
    {
        _targetEuler = newTargetEuler;
    }

    public Vector3 GetCurrentEuler()
    {
        return _targetEuler;
    }
}
