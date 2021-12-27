using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RopeState
{
    Disable,
    Fly,
    Active
}

public class RopeGun : MonoBehaviour
{
    public Hook Hook;
    public Transform Spawn;
    public float Speed;
    public Transform RopeStart;

    public RopeRenderer RopeRenderer;

    public PlayerMove PlayerMove;

    private SpringJoint _springJoint;
    private float _ropeLength;
    private RopeState _currentRopeState;

    private void Update()
    {
        if(Input.GetMouseButtonDown(2))
        {
            Shot();
        }

        if(_currentRopeState == RopeState.Fly)
        {
            float distance = Vector3.Distance(RopeStart.position, Hook.transform.position);

            if (distance > 20)
                DestroySpring();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_currentRopeState == RopeState.Active && !PlayerMove.Grounded)
                PlayerMove.Jump();
            DestroySpring();
        }

        if ((int)_currentRopeState > 0)
            RopeRenderer.Draw(RopeStart.position, Hook.transform.position, _ropeLength);
    }

    void Shot()
    {
        if (_springJoint)
            Destroy(_springJoint);

        Hook.gameObject.SetActive(true);
        Hook.StopFix();
        Hook.transform.position = Spawn.position;
        Hook.transform.rotation = Spawn.rotation;
        Hook.HookRigidbody.velocity = Spawn.forward * Speed;

        _currentRopeState = RopeState.Fly;
        _ropeLength = 1;
    }

    public void CreateSpring()
    {
        if(_springJoint==null)
        {
            _springJoint = gameObject.AddComponent<SpringJoint>();

            _springJoint.connectedBody = Hook.HookRigidbody;
            _springJoint.anchor = RopeStart.localPosition;
            _springJoint.autoConfigureConnectedAnchor = false;
            _springJoint.connectedAnchor = Vector3.zero;
            _springJoint.spring = 1000;
            _springJoint.damper = 50;

            _ropeLength = Vector3.Distance(RopeStart.position, Hook.transform.position);
            _springJoint.maxDistance = _ropeLength;

            _currentRopeState = RopeState.Active;
        }
    }

    public void DestroySpring()
    {
        Destroy(_springJoint);
        _currentRopeState = RopeState.Disable;

        Hook.gameObject.SetActive(false);

        RopeRenderer.Hide();
    }
}
