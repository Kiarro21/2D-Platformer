using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Player Movement Settings")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForse = 6f;

    private float horizontalMove = 0f;
    private bool playerDirectionMove = true;


    [Header("Ground Checker Settings")]
    [SerializeField] private bool isGround = false;
    private float checkGroundRadius = 0.1f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask; 

    [Header("Animation Settings")]
    private Animator anim;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update(){

        CheckGround();
        if (isGround && Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }

        if (isGround == false){
            anim.SetBool("Jump", true);
        }
        else{
            anim.SetBool("Jump", false);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * speed;

        anim.SetFloat("Walk", Mathf.Abs(horizontalMove));

        if (horizontalMove < 0 && playerDirectionMove){
            Flip();
        }
        else if (horizontalMove > 0 && !playerDirectionMove){
            Flip();
        }

    }

    private void Jump(){
        rb.AddForce(transform.up * jumpForse, ForceMode2D.Impulse);
        anim.SetBool("Jump", true);
    }

    private void FixedUpdate() {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime, 0, 0);
    }

    private void Flip(){
        playerDirectionMove = !playerDirectionMove;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void CheckGround(){
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkGroundRadius, groundMask);
    }

    private void LadderMove(){
        rb.velocity = Vector2.up * 2f;
    }

    void OnTriggerStay2D(Collider2D other){
        if (other.CompareTag("Ladder")){
            LadderMove();
        }
    }
    

    private enum States { Idle, Walk, Jump }

    //private enum DirectionMove { Left, Right }
}
