using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float currentHP = 100f;
    [SerializeField] private Text currentHpText;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
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
        float disX = Random.Range(-5f, 5f), disY = Random.Range(0f, 5f);
        rb.AddForce(new Vector2(disX, disY), ForceMode2D.Impulse);
    }

    private void ChangeCurrHpText(){
        currentHpText.text = currentHP.ToString();
    }
}