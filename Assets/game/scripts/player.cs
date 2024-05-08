using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    // Start is called before the first frame update
    
    public float moveSpeed = 5f;
    public float rollBoost = 2f;
    private float rollTime;
    public float RollTime;
    bool rollone = false;
    private RigidbodyType2D rb;
    public Vector3 moveInput;
    
    public Animator animator;
    public SpriteRenderer characterSR;
    private void Start(){
        animator = GetComponent<Animator>();
    }
    private void Update(){
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
        transform.position += moveInput * moveSpeed * Time.deltaTime;
        animator.SetFloat("seep", moveInput.sqrMagnitude);
        if ( Input .GetKeyDown(KeyCode.Space) && rollTime <= 0 ){
            animator.SetBool("roll",true);
            moveSpeed += rollBoost;
            rollTime = RollTime;
            rollone =true;

        }
        if(rollTime <= 0 && rollone == true){
             animator.SetBool("roll",false);
            moveSpeed -= rollBoost;
            rollone = false;

        }
        else{
            rollTime -= Time.deltaTime;
        }

        if(moveInput.x != 0){
            if(moveInput.x > 0){
                characterSR.transform.localScale = new Vector3(1,1,1);
            }
            else characterSR.transform.localScale = new Vector3(-1,1,1);
        }


    }   
    public Health playerHeal;
    public void TakeDamage(int damage){
        playerHeal.TakeDam(damage);
        
    }     
    
}

    
