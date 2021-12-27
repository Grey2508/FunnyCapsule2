using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int Health = 5;
    public int MaxHealth = 8;

    //public AudioSource TakeDamageSound;
    public PitchAndPlay AddHealthSound;

    public HealthUI HealthUI;

    //public DamageScreen DamageScreen;
    //public Blink Blink;

    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;

    private bool _invulnerable = false; //неуязвимость

    private void Start()
    {
        HealthUI.Setup(MaxHealth);
        HealthUI.DisplayHealth(Health);
    }

    public void TakeDamage(int damageValue)
    {
        if (!_invulnerable)
        {
            Health -= damageValue;

            HealthUI.DisplayHealth(Health);

            if (Health <= 0)
            {
                Health = 0;
                Die();
            }

            _invulnerable = true;
            Invoke("StopInvulnerable", 1);

            EventOnTakeDamage.Invoke();
            //DamageScreen.StartEffect();
            //Blink.StartEffect();
            //TakeDamageSound.pitch = Random.Range(0.8f, 1.2f);
            //TakeDamageSound.Play();
        }
    }

    public void AddHealth(int healthValue)
    {
        Health += healthValue;
        
        HealthUI.DisplayHealth(Health);

        AddHealthSound.Play();

        if (Health > MaxHealth)
        {
            Health = MaxHealth;
        }
    }

    private void Die()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        EventOnDie.Invoke();

        Debug.Log("You lose");
    }

    private void StopInvulnerable()
    {
        _invulnerable = false;
    }
}
