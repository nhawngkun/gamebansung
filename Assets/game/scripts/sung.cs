using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class sung : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePos;
    public float TimeBtwFire =0.2f;
    public float bullerForce;
    private float timeBtwFire;
   

    // Update is called once per frame
    void Update()

    {
        RotateGum(); 
        timeBtwFire -= Time.deltaTime;
        if ( Input.GetMouseButton(0) && timeBtwFire <0){
            FireBullet();
        }       
    }
    void RotateGum(){
        Vector3 monsePos  = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 lookDir = monsePos - transform.position;
        float angle =  Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg;
        
        Quaternion rotation = Quaternion.Euler(0,0,angle);   
        transform.rotation = rotation;
        if (transform.eulerAngles.z>90 && transform.eulerAngles.z<270){
            transform.localScale = new Vector3(-6, -6,0);

        }else transform.localScale = new Vector3(6, 6,0);







         }
         void FireBullet(){
            timeBtwFire = TimeBtwFire;
            GameObject bulletTmp = Instantiate(bullet,firePos.position, Quaternion.identity);
            Rigidbody2D rb = bulletTmp.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right*bullerForce,ForceMode2D.Impulse);

         }
        
   
}
