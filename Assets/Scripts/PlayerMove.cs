using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody PlayerBody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public float MaxAngleGround;
    public float MaxSpeed;
    public Transform ColliderTransform;
    public Transform RayStart;

    private float _jumpFrameCounter = 3;
    public bool Grounded
    {
        get;
        private set;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)
            || Input.GetKey(KeyCode.S) || !Grounded)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15);
        }
        else
        {
            if (Physics.Raycast(RayStart.position, Vector3.up, out RaycastHit hit, 10, 1))
            {
                if (hit.distance > 1)
                    ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15);
            }
            else
                ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
                Jump();
        }
    }

    public void Jump()
    {
        PlayerBody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);

        _jumpFrameCounter = 0;
    }

    private void FixedUpdate()
    {
        float speedMultiplier = (Grounded ? 1f : 0.2f);
        if (!Grounded)
        {
            if (PlayerBody.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0)
                speedMultiplier = 0;
            if (PlayerBody.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0)
                speedMultiplier = 0;
        }

        PlayerBody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);

        if (Grounded)
        {
            PlayerBody.AddForce(-PlayerBody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, Time.deltaTime * 15);
        }

        _jumpFrameCounter++;

        if (_jumpFrameCounter == 2)
        {
            PlayerBody.freezeRotation = false;
            PlayerBody.AddRelativeTorque(0, 0, 10, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < MaxAngleGround && !Grounded)
        {
            Grounded = true;
            PlayerBody.freezeRotation = true;
        }

        if (collision.contactCount == 1) //чтобы при падении на наклонную поверхность не оставался в полный рост
        {
            if (angle > MaxAngleGround)
                Grounded = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
}
