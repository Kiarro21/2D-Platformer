using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    [SerializeField] private float currentHealth = 100f;
    [SerializeField] private float maxHeath = 100f;
    [SerializeField] private Text healthText;
    [SerializeField] private bool isCooldown = false;
    
    public void TakeHit(float damage){
        if (currentHealth <= 0){
            Destroy(gameObject);
            return;
        }
        currentHealth -= damage;
        ChangeHealthText();
    }

    public void AddHealth(float add){
        currentHealth += add;

        if (currentHealth > maxHeath){
            currentHealth = maxHeath;
        }

        ChangeHealthText();
    }

    private void ChangeHealthText(){
        healthText.text = currentHealth.ToString();

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Spike" && !isCooldown){
            currentHealth -= 10;
            if (currentHealth <= 0){
                Destroy(gameObject);
            }
            ChangeHealthText();
            StartCoroutine(HitCooldown());
        }
    }

    IEnumerator HitCooldown(){
        isCooldown = true;
        yield return new WaitForSeconds(2f);
        isCooldown = false;
    }

}
