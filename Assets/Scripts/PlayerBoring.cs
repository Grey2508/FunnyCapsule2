using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoring : MonoBehaviour
{
    public Animator PlayerAnimator;
    public float BoringTime = 3;

    private float _timer;
    private bool _IsAnimationOn = false;
    private Vector3 _prevMouseCoords;

    void Update()
    {
        if ((Input.anyKey) || (Input.mousePosition != _prevMouseCoords))
        {
            _timer = 0;

            if (_IsAnimationOn)
            {
                PlayerAnimator.SetTrigger("StopBoring");
                _IsAnimationOn = false;
            }

            _prevMouseCoords = Input.mousePosition;
        }

        if (_IsAnimationOn)
            return;

        _timer += Time.deltaTime;

        if (_timer > BoringTime)
        {
            _timer = 0;
            
            PlayerAnimator.SetTrigger($"Boring{Random.Range(1, 4)}");
            _IsAnimationOn = true;
        }
    }

    public void AnimationEnd()
    {
        _IsAnimationOn = false;
    }
}
