using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Rigth
}

public class Patrol : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;

    public float Speed = 1;

    public float StopTime = 0.5f;

    public Direction CurrentDirection;
    
    public Transform RayStart;

    private bool _isStopped;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }

    private void Update()
    {
        if (_isStopped)
            return;

        int sign = (CurrentDirection == Direction.Left ? -1 : 1);
        transform.position += new Vector3(Time.deltaTime * Speed, 0, 0) * sign;

        if (transform.position.x < LeftTarget.position.x)
        {
            CurrentDirection = Direction.Rigth;
            _isStopped = true;
            Invoke("ContinuePatrol", StopTime);

            EventOnLeftTarget.Invoke();
        }
        if (transform.position.x > RightTarget.position.x)
        {
            CurrentDirection = Direction.Left;
            _isStopped = true;
            Invoke("ContinuePatrol", StopTime);

            EventOnRightTarget.Invoke();
        }

        RaycastHit hit;
        if(Physics.Raycast(RayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    void ContinuePatrol()
    {
        _isStopped = false;
    }

    //”ничтожить точки
    private void OnDestroy()
    {
        if (LeftTarget != null)
            Destroy(LeftTarget.gameObject);
        if (RightTarget != null)
            Destroy(RightTarget.gameObject);
    }
}
