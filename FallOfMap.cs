using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FallOfMap : MonoBehaviour
{

     public GameOver call;
    public CinemachineVirtualCamera cam;
     public GameObject ground;

    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
        Debug.Log("Player fell");
        cam.Follow=ground.transform;
        call.EnableGameOver();
        }
    }
}
