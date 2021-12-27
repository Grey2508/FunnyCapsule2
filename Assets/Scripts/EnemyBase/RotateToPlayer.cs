using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    public float RotationSpeed = 3;

    public float LeftAngle = -30;
    public float RightAngle = -150;

    public Transform Spawn = null;

    private Transform _playerTransform;

    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float y = (_playerTransform.position.x < transform.position.x ? LeftAngle : RightAngle);

        //Поворот спауна, если назначен в инспекторе
        if (Spawn != null) 
        {
            Vector3 spawnRotation = Spawn.localRotation.eulerAngles; //получение текущего вращения

            float x = y < -90 ? 180 + y : y; //выравнивание направления оси Z в плоскость игры

            float z = (spawnRotation.x > 180 ? 0 : 180); //Смена направления оси Z при повороте за игроком

            Spawn.localRotation = Quaternion.Euler(x, spawnRotation.y, z);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, y, 0), Time.deltaTime * RotationSpeed);
    }
}
