using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointControl : MonoBehaviour
{
    public Transform ControlledTransform;
    public RopeGun RopeGun;

    private Vector3 _currentCheckpount = Vector3.zero;

    public void SetNewCheckpoint (Vector3 newCheckpoint)
    {
        _currentCheckpount = newCheckpoint;
    }

    public void ToCheckpoint()
    {
        RopeGun.DestroySpring();
        ControlledTransform.position = _currentCheckpount;
    }

}
