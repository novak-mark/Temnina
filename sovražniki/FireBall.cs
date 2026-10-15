using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    private float timer=0;
    public int dmg;
    void Start()
    {
     
    }
    // Update is called once per frame
    void Update()
    {
        timer+=Time.deltaTime;
        if(timer>10){
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            other.GetComponent<PHealth>().TakeDamageCombat(dmg);
            Debug.Log("Player hit");
            Destroy(gameObject);
        }
    }
}
