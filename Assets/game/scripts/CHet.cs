using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CHet : MonoBehaviour
{
    public UnityEvent healthBar;
    public UnityEvent OnDeath;
    public void Death(){
        Destroy(gameObject);
    }
    
    // Start is called before the first frame update
}