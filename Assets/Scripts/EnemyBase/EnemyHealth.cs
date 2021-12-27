using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 1;
    
    public GameObject[] Loot;

    public UnityEvent EventOnTakeDamage;
    public UnityEvent EventOnDie;


    public void TakeDamage(int damageValue)
    {
        Health -= damageValue;

        EventOnTakeDamage.Invoke();

        if (Health <= 0)
            Die();
    }

    private void Die()
    {
        if ((Loot.Length > 0) && (Random.Range(1, 100) % 3 == 0))
            Instantiate(Loot[Random.Range(0, Loot.Length)], transform.position, Quaternion.identity);

        EventOnDie.Invoke();

        Destroy(gameObject);
    }
}
