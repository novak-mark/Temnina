using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PBullet : MonoBehaviour
{
   
    private Rigidbody2D rb;
    private GameObject player;
    private float timer;
    public int dmg;
      private float bulletSpeed;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();  
        player=GameObject.FindGameObjectWithTag("Player");
        rb.velocity=transform.right*3;
    }
    void Update()
    {
        /*preverjamo koliko dolgo je pušcica v igri, in če je to daljše od 10 sekund jo uničimo*/
        
        timer+=Time.deltaTime;
        if(timer>10){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            if(other.GetComponent<EnemyHealth>()!=null){
            other.GetComponent<EnemyHealth>().TakeDamage(dmg);
            }
            else if(other.GetComponent<FlyingEnemyHealth>()!=null){
            other.GetComponent<FlyingEnemyHealth>().TakeDamage(dmg);
        }
            Destroy(gameObject);
    }
}
}
