using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Enemy
{
    [SerializeField] private float goblinDamage;

    public override void TakeDamage(float damage){
        base.TakeDamage(damage);
    }

}
