using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Traps
{

    [SerializeField] private float attackDamage = 20f;
    [SerializeField] private float attackCooldown = 0.5f;

    public override void ApplyDamage(float damage){
        if (!isCooldown){
            base.ApplyDamage(damage);
            StartCoroutine(AttackCooldown(attackCooldown));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            ApplyDamage(attackDamage);
        }
    }

}
