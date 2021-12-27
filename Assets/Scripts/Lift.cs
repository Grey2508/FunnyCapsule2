using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Lift : MonoBehaviour
{
    public Rigidbody LiftBody;
    public float LiftSpeed = 1;

    public float MaxHeight = 0;
    private float _minHeight = 0;

    private bool _startLift = false;
    private float _timer;
    private bool _leave = false;

    private void Start()
    {
        _minHeight = transform.position.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _startLift = true;
            _timer = 0;
            _leave = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _leave = true;
        }
    }

    private void FixedUpdate()
    {
        if (_startLift)
        {
            if (transform.position.y < MaxHeight)
                LiftBody.MovePosition(transform.position + Vector3.up * LiftSpeed);
            else
                transform.position = new Vector3(transform.position.x, MaxHeight, transform.position.z);

        }

        if (!_startLift)
        {
            if (transform.position.y > _minHeight)
                LiftBody.MovePosition(transform.position - Vector3.up * LiftSpeed);
            else
                transform.position = new Vector3(transform.position.x, _minHeight, transform.position.z);
        }

        if (_leave && _startLift)
        {
            _timer += Time.deltaTime;

            if (_timer > 1)
            {
                _startLift = false;

                _timer = 0;
            }
        }
    }
}
