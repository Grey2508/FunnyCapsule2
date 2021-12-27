using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasNozzle : MonoBehaviour
{
    public ParticleSystem Gas;
    public float MinPeriod = 0.5f;
    public float MaxPeriod = 3;
    public BoxCollider Trigger;
    public PitchAndPlay Spray;

    private float _timer;
    private bool _isCountTime = true;
    private float _currentPeriod = 2;

    void Update()
    {
        if (_isCountTime)
            _timer += Time.deltaTime;

        if (_timer > _currentPeriod)
        {
            Warning();
            Invoke("Warning", 0.7f);
            Invoke("Attack", 1.4f);

            _isCountTime = false;
            _timer = 0;

            _currentPeriod = Random.Range(MinPeriod, MaxPeriod);
        }
    }

    private void Warning()
    {
        Gas.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);

        float duration = 0.2f;

        var main = Gas.main;
        main.duration = duration;
        main.startLifetime = 0.9f;

        Gas.Play();
        Spray.Play();
        Invoke("OffSound", duration);
    }

    private void Attack()
    {
        Gas.Stop(false, ParticleSystemStopBehavior.StopEmittingAndClear);

        float duration = 1;

        var main = Gas.main;
        main.duration = duration;
        main.startLifetime = 1;

        Gas.Play();
        Spray.Play();
        Invoke("TriggerOn", 0.4f);
        Invoke("OffSound", duration);
    }

    private void TriggerOn()
    {
        Trigger.enabled = true;

        Invoke("TriggerOff", 0.6f);
    }

    private void TriggerOff()
    {
        Trigger.enabled = false;
        _isCountTime = true;
    }

    private void OffSound()
    {
        Spray.Stop();
    }
}
