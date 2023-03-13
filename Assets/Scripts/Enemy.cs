using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float currentHelth;
    [SerializeField] private float maxHealth;

    private Animator anim;

    public bool isCooldown = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void ApplyDamage(float damage){
        Player.instance.TakeHit(damage);
    }

    public virtual void TakeDamage(float damage){
        anim.SetTrigger("TakeHit");
        currentHelth -= damage;
        Die();
    }

    public void Die(){
        if (currentHelth <= 0)
            Destroy(gameObject);
    }

    public IEnumerator AttackCooldown(float timeCooldown){
        isCooldown = true;
        yield return new WaitForSeconds(timeCooldown);
        isCooldown = false;
    }
}
