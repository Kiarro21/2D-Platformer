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

    private SpriteRenderer playerSprite;

    private void Awake(){
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        currentHP = maxHP;
        currentHpText.text = currentHP.ToString();
    }

    private void Update(){
        ChangeCurrHpText();
    }

    public void TakeHit(float damage){
        currentHP -= damage;
        if (currentHP <= 0){
            currentHP = 0;
            Destroy(gameObject);
        }
        Discarding();
        ChangeCurrHpText();
    }

    private void Discarding(){
        rb.AddForce(new Vector2(0,1) * 4f, ForceMode2D.Impulse);
        playerSprite.color = new Color(255, 80, 80, 255);
    }



    private void ChangeCurrHpText(){
        currentHpText.text = currentHP.ToString();
    }
}
