using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera PlayerCamera;

    public Transform Body;
    public float LerpSpeed;

    void LateUpdate()
    {
        //создание луча в позицию курсора
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);

        //отрисовка луча
        Debug.DrawRay(ray.origin, ray.direction * 50f, Color.yellow);

        //создание плоскости
        Plane plane = new Plane(Vector3.back, Vector3.zero);

        //Получение точки пересечения плоскости и луча
        plane.Raycast(ray, out float distance);
        Vector3 point = ray.GetPoint(distance);
        
        //задание позиции прицела
        Aim.position = point;

        //вычисление вектора направления к прицелу
        Vector3 toAim = Aim.position - transform.position;

        //поворот оружия
        transform.rotation = Quaternion.LookRotation(toAim);

        //Поворот персонажа
        float y = Mathf.Clamp(toAim.x * -40, -40, 40);
        Body.localRotation = Quaternion.Lerp(Body.transform.localRotation, Quaternion.Euler(0, y, 0), LerpSpeed);
    }
}
