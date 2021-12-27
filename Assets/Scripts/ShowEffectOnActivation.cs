using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEffectOnActivation : MonoBehaviour
{
    public ParticleSystem Effect;
    public float ZPosition = -2;

    private void OnEnable()
    {
        Vector3 effectPosition = new Vector3(transform.position.x, transform.position.y, ZPosition);

        Instantiate(Effect, effectPosition, Quaternion.identity);
    }
}
