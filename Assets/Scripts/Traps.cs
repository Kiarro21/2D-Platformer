using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Traps : MonoBehaviour
{
    public bool isCooldown = false;


    public virtual void ApplyDamage(float damage){
        Player.instance.TakeHit(damage);
    }

    public IEnumerator AttackCooldown(float timeCooldown){
        isCooldown = true;
        yield return new WaitForSeconds(timeCooldown);
        isCooldown = false;
    }
}
