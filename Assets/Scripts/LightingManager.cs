using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    public float Speed = 1;

    private float _targetIntensity;
    private Light _light;

    private void Start()
    {
        _light = GetComponent<Light>();
    }

    public void SetCastShadows(bool IsCastShadows)
    {
        _light.shadows = (IsCastShadows ? LightShadows.Soft : LightShadows.None);
    }

    public void SetIntensity(float newIntensity)
    {
        _targetIntensity = newIntensity;

        StartCoroutine(ChangeIntensity());
    }

    private IEnumerator ChangeIntensity()
    {
        float sign = _light.intensity > _targetIntensity ? -1 : 1;

        for (float i = _light.intensity; Mathf.Abs(i - _targetIntensity) > 0.05f; i += Time.deltaTime * Speed * sign)
        {
            _light.intensity = i;

            yield return null;
        }

        _light.intensity = _targetIntensity;
    }
}
