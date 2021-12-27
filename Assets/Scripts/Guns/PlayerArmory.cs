using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmory : MonoBehaviour
{
    public Gun[] Guns;
    public int CurrentGunIndex;

    void Start()
    {
        TakeGunByIndex(CurrentGunIndex);
    }

    public void TakeGunByIndex(int gunIndex)
    {
        Guns[CurrentGunIndex].Deactivate();
        Guns[gunIndex].Activate();

        CurrentGunIndex = gunIndex;
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        Guns[gunIndex].AddBullets(numberOfBullets);
    }
}
