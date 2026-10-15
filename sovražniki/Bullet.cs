using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject Player;
    private Rigidbody2D rb;
    public float speed;
    private float timer;
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Player=GameObject.FindGameObjectWithTag("Player");
        Vector3 direction=Player.transform.position-transform.position;
        rb.velocity=new Vector2(direction.x,direction.y).normalized*speed;
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
        if(other.gameObject.CompareTag("Player")){
            other.GetComponent<PHealth>().TakeDamageCombat(30);
            Debug.Log("Player hit");
            Destroy(gameObject);
        }
    }
}
