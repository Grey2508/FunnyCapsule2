using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

public class JumpGun : MonoBehaviour
{
    public Rigidbody PlayerRigidbogy;
    public float Force = 5;
    public Transform Spawn;
    public PlayerArmory PlayerArmory;

    public ChargeIcon ChargeIcon;

    public float MaxCharge = 3;

    private float _currentCharge;
    private bool _isCharged;

    private void Update()
    {
        if (_isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                PlayerRigidbogy.AddForce(-Spawn.forward * Force, ForceMode.VelocityChange);
                PlayerArmory.Guns[PlayerArmory.CurrentGunIndex].Shot();

                _isCharged = false;
                _currentCharge = 0;
                ChargeIcon.StartCharge();
            }
        }
        else
        {
            _currentCharge += Time.unscaledDeltaTime;
            ChargeIcon.SetChargeValue(_currentCharge, MaxCharge);

            if (_currentCharge >= MaxCharge)
            {
                _isCharged = true;
                ChargeIcon.StopCharge();
            }
        }
    }

}
