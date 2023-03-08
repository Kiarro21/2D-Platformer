using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float currentHP = 100f;
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private Text currentHpText;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        currentHP = maxHP;
        currentHpText.text = currentHP.ToString();
    }

    public void TakeHit(float damage){
        currentHP -= damage;
        Discarding();
        ChangeCurrHpText();
        if (currentHP <= 0){
            Destroy(gameObject);
        }
    }

    public void Discarding(){
        float disX = Random.Range(-3f, 3f), disY = Random.Range(0f, 5f);
        rb.AddForce(new Vector2(disX, disY), ForceMode2D.Impulse);
    }

    private void ChangeCurrHpText(){
        currentHpText.text = currentHP.ToString();
    }
}
