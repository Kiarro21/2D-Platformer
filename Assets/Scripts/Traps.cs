using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Traps : MonoBehaviour
{
    [SerializeField] private Player player;
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
