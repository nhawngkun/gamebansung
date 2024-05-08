using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sungquai : MonoBehaviour
{
    public bool isShootble = false;
    public GameObject bullet;
    public float bulletSpeed;
    public float timeBtwFire;
    private float fireCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if(fireCooldown < 0){
            fireCooldown = timeBtwFire;
            EnemyFireBullet();
        }
        void EnemyFireBullet(){
            var bulletTmp = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
            Vector3 playPos = FindObjectOfType<player>().transform.position;
            Vector3 direction = playPos - transform.position;
            rb.AddForce(direction.normalized * bulletSpeed,ForceMode2D.Impulse);
        }
        
    }
}
