using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public static Player instance;

    private Rigidbody2D rb;
    private SpriteRenderer playerSprite;
    private Animator anim;


    [SerializeField] private float currentHP = 100f;
    [SerializeField] private float maxHP = 100f;
    [SerializeField] private Text currentHpText;

    [Header("Attack Settings")]
    [SerializeField] private float damage = 15f;
    [SerializeField] private Transform attackPos;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float attackRange;
    [SerializeField] private float startTimeBtwAttack;
    private float timeBtwAttack;


    private void Awake(){
        if (instance == null)
            instance = this;
        else if (instance == this)
            Destroy(gameObject);
        rb = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Start() {
        currentHP = maxHP;
        currentHpText.text = currentHP.ToString();
    }

    private void Update(){

        if (timeBtwAttack <= 0){
            if (Input.GetMouseButtonDown(0)){
                anim.SetTrigger("Attack");
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else{
            timeBtwAttack -= Time.deltaTime;
        }

        ChangeCurrHpText();
    }

    public void Attack(){
        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, layerMask);
        for (int i = 0; i < enemiesToDamage.Length; i++)
        {
            enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
        }
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

    private void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void Discarding(){ 
        rb.AddForce(new Vector2(0,1) * 4f, ForceMode2D.Impulse);
        playerSprite.color = new Color(255, 80, 80, 255);
    }



    private void ChangeCurrHpText(){
        currentHpText.text = currentHP.ToString();
    }
}
