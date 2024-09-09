using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class RedEnemy : Enemy
{
    // Start is called before the first frame update
    void Start()
    {
        // INHERITANCE
        Health = 20;
        AttackPower = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // POLYMORPHISM
    public override void Attack(Player player)
    {
        player.TakeDamage(AttackPower * 3);
    }


}
