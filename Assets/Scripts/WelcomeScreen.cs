using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{
    public GameObject Box;

    public void SwitchOfBox()
    {
        Box.SetActive(false);
    }
    public void Disabled()
    {
        gameObject.SetActive(false);
    }
}
