using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class RedEnemy : Enemy
{
    private float topBound = 30.0f;
    private float lowerBound = -10f;
    
    // Start is called before the first frame update
    void Start()
    {
        // INHERITANCE
        Health = 20;
        AttackPower = 5;
        Speed = 7;
               
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();

        DestroyOutOfBound();

    }

    // POLYMORPHISM
    public override void Attack(Player player)
    {
        player.TakeDamage(AttackPower * 3);
    }

    // ABSTRACTION
    // Method to handle collision
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Player player = other.gameObject.GetComponent<Player>();
            if (player != null)
            {
                Attack(player);                
            };
        }
    }

    // ABSTRACTION
    // Method to handle destruction of enemy after passing player
    void DestroyOutOfBound()
    {
        // If an object goes past the players view in the game, remove that object
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }

}
