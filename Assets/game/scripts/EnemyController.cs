using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    player PlayerS;
    public int minDamage;
    public int maxDamage;
    Health health1;
    private void Start(){
        health1 = GetComponent<Health>();
    }
    public void TakeDamage(int damage){
        health1.TakeDam(damage);
    } 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerS = collision.GetComponent<player>();
            InvokeRepeating("DamagePlayer", 0, 0.1f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CancelInvoke("DamagePlayer");
            PlayerS = null;
        }
    }

    void DamagePlayer()
    {
        int damage = Random.Range(minDamage, maxDamage);
        PlayerS.TakeDamage(damage);
    }
}