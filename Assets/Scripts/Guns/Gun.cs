using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform Spawn;
    public float BulletSpeed = 10;
    public float ShotPeriod = 0.2f;

    //public AudioSource ChooseSound; //Звук выбора оружия
    public PitchAndPlay ShotSound; //Звук выстрела
    public GameObject Flash;
    public ParticleSystem ShotEffect;

    public bool Automatic; //автоматическое оружие или самозарядное

    private float _timer;

    void Update()
    {
        _timer += Time.unscaledDeltaTime;

        bool shot = (Automatic ? Input.GetMouseButton(0) : Input.GetMouseButtonDown(0)); //атоматическое оружие стреляет очередями, самозарядное - одиночными

        if (_timer > ShotPeriod && shot)
        {
            _timer = 0;

            Shot();
        }
    }

    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(BulletPrefab, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;

        ShotSound.Play();

        Flash.SetActive(true);
        Invoke("HideFlash", 0.2f);

        ShotEffect.Play();
    }

    private void HideFlash()
    {
        Flash.SetActive(false);
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public virtual void AddBullets(int numberOfBullets)
    {

    }
}