using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticRifle : Gun
{
    [Header("AutomaticRifle")]
    public int NumberOfBullets = 0;
    public Text BulletsText;
    public PlayerArmory PlayerArmory;

    public override void Shot()
    {
        base.Shot();

        NumberOfBullets--;
        UpdateText();

        if (NumberOfBullets == 0)
            PlayerArmory.TakeGunByIndex(0);
    }

    public override void Activate()
    {
        base.Activate();

        UpdateText();
        BulletsText.enabled = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        BulletsText.enabled = false;
    }

    void UpdateText()
    {
        BulletsText.text = $"Bullets: {NumberOfBullets}";
    }

    public override void AddBullets(int numberOfBullets)
    {
        base.AddBullets(numberOfBullets);

        NumberOfBullets += numberOfBullets;
        UpdateText();

        PlayerArmory.TakeGunByIndex(1);
    }
}
