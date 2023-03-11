using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float currentHelth;
    [SerializeField] private float maxHealth;

    public bool isCooldown = false;

    public virtual void ApplyDamage(float damage){
        player.TakeHit(damage);
    }


    public IEnumerator AttackCooldown(float timeCooldown){
        isCooldown = true;
        yield return new WaitForSeconds(timeCooldown);
        isCooldown = false;
    }
}
