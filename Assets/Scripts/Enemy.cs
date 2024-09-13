using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ENCAPSULATION
    // common properties for all enemies
    private int health;
    private int attackPower;
    private float speed;

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

    public float Speed
    {
        get { return speed; }
        set
        {
            // Damage must be a non-negative value
            if (value < 0)
                speed = 0;
            else
                speed = value;
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

    // ABSTRACTION
    // Method to handle movement
    public void EnemyMovement()
    {
        // Move enemy
        transform.Translate(-Vector3.forward * Time.deltaTime * speed);

        if (transform.position.y < -10)
        {
            Die();
        }
    }


}
