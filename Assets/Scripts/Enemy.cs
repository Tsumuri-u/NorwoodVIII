using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public KeyCode flashKey;
    public SimpleFlash flashEffect;
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;
        flashEffect.Flash();
        if(currentHealth <= 0) {
            Die();
        }
    }

    void Die() {
        Debug.Log("Enemy Died");
    }
}
