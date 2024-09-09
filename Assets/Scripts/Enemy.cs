using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ENCAPSULATION
    // common properties for all enemies
    private int health;
    private int attackPower;

    public int Health
    {
        get { return health; }
        set
        {           
            if (value < 0)
                health = 0;
            else
                health = value;
        }
    }

    public int AttackPower
    {
        get { return attackPower; }
        set
        {
            // Damage must be a non-negative value
            if (value < 0)
                attackPower = 0;
            else
                attackPower = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ABSTRACTION
    // Method to handle taking damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
        
    }

    // ABSTRACTION
    // Method to handle attacking
    public virtual void Attack(Player player)
    {        
        player.TakeDamage(attackPower);
    }

    // ABSTRACTION
    // Method to handle death
    public void Die()
    {       
        Destroy(gameObject); // Remove the enemy from the scene
    }

    
}
